var gradovi=[];

export class Grad{
    constructor(id,ime){
        this.id=id;
        this.ime=ime;
    }
    returnGradovi(){
        return gradovi;
    }
    async ucitajGradove(){
        gradovi=[];
        document.getElementById("select_grad").options.length=0;
        await fetch(`https:localhost:5001/Grad/VratiGradove`,{
            method: "GET"
        }).then(p => {
            p.json().then(data => {
                data.forEach(grad => {
                    gradovi.push(new Grad(grad.id,grad.ime));
                    var opt = document.createElement("option");
                    opt.value = grad.ime;
                    opt.innerHTML = grad.ime;
                    document.getElementById("select_grad").appendChild(opt);
                });
                });
            });
    }
    async dodajGrad(){
        var string_grad = document.getElementById('ime_grada').value;
        if (string_grad==""){
            alert("Popunite polje.");
            return
        }
        await fetch(`https:localhost:5001/Grad/DodajGrad`,{
            method: "POST",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify({
                ime:string_grad
            })
        }).then(p => {
            if (p.status == 400) {
                alert("Grad vec postoji.");
            }
        });
        this.ucitajGradove();
    }
    async obrisiGradove() {
        if (gradovi==[]){
            alert("Nema gradova za brisanje.");
            return;
        }
        gradovi=[];
        await fetch(`https:localhost:5001/Grad/ObrisiGradove`,{
            method: "DELETE"
        });
        document.getElementById("select_grad").options.length=0;
    }    
}