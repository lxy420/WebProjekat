var izvodjaci_niz=[]

export class Izvodjac{
    constructor(id,ime,prezime,instrument){
        this.id=id;
        this.ime=ime;
        this.prezime=prezime;
        this.instrument=instrument;
    }
    returnIzvodjace(){
        return izvodjaci_niz;
    }
    async dodajIzvodjaca(){
        if (document.getElementById("input_izvodjac_ime").value=="" 
        || document.getElementById("input_izvodjac_prezime").value=="" 
        || document.getElementById("input_izvodjac_instrument").value==""){
            alert("Popunite polje.");
            return
        }
        await fetch(`https:localhost:5001/Izvodjac/DodajIzvodjaca`,{
            method: "POST",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify({
                ime:document.getElementById("input_izvodjac_ime").value,
                prezime:document.getElementById("input_izvodjac_prezime").value,
                instrument:document.getElementById("input_izvodjac_instrument").value
            })
        }).then(p => {
            if (p.status == 400) {
                alert("Izvodjac vec postoji.");
            }
        });
         this.ucitajIzvodjace();
    }
    async ucitajIzvodjace(){
        izvodjaci_niz=[];
        var s=document.getElementById("select_izvodjac");
        document.getElementById("select_izvodjac").length=0;
        await fetch(`https:localhost:5001/Izvodjac/VratiIzvodjace`,{
                method: "GET"
                }).then(p => {
                    p.json().then(data => {
                        data.forEach(i => {
                            izvodjaci_niz.push(new Izvodjac(i.id,i.ime,i.prezime,i.instrument));
                            var opt = document.createElement("option");
                            opt.value = i.ime;
                            opt.innerHTML = i.ime;
                            document.getElementById("select_izvodjac").appendChild(opt);
                        });
                        });
                    });

    }
    async obrisiIzvodjace() {
        if (izvodjaci_niz==[]){
            alert("Nema izvodjaca za brisanje.");
            return;
        }
        izvodjaci_niz=[];
        await fetch(`https:localhost:5001/Izvodjac/ObrisiIzvodjace`,{
            method: "DELETE"
        })
        document.getElementById("select_izvodjac").options.length=0;
    }
   
}