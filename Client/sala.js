import {Grad} from "./grad.js";
var gradovi=[];
var sale_niz=[];

export class Sala{
    constructor(id,ime,kapacitet){
        this.id=id;
        this.ime=ime;
        this.kapacitet=kapacitet;
        document.getElementById("select_grad").addEventListener('change',(e)=>{
            this.ucitajSale();
        });
    }
    setGradovi(g){
        gradovi=g;
    }
    returnSale(){
        return sale_niz;
    }
    drawSala(){
        if(document.getElementById("div_sala")!=null)
            document.getElementById("div_sala").remove();

        const div_sala = document.createElement("div");
        div_sala.setAttribute("id","div_sala")
        document.getElementById("div_form").append(div_sala);

        const div_sedista = document.createElement("div");
        div_sedista.setAttribute("id","div_sedista")
        document.getElementById("div_sala").append(div_sedista);

        for(let i=0;i<this.kapacitet;i++){
            const div_sediste  = document.createElement('div');
            div_sediste.className = 'div_sediste_slobodno';
            div_sediste.setAttribute("id",i+1);
            div_sediste.innerText=i+1;
            document.getElementById('div_sedista').appendChild(div_sediste);
            div_sediste.addEventListener('click', function handleClick() {
                if(div_sediste.className=="div_sediste_slobodno")
                    div_sediste.className = 'div_sediste_zauzeto';
                else
                    div_sediste.className = 'div_sediste_slobodno';
            })
        }

    }
    async dodajSalu() {
        var string_ime = document.getElementById('ime_sale').value;
        var string_kapacitet = document.getElementById('kapacitet_sale').value;
        var g=gradovi.find(g=>g.ime==document.getElementById("select_grad").value);

        if (string_ime=="" || string_kapacitet==""){
            alert("Popunite sva polja.");
            return
        }
        await fetch(`https:localhost:5001/Sala/DodajSalu/`+g.id,{
            method: "POST",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify({
                ime:string_ime,
                kapacitet:string_kapacitet
            })
        })
         this.ucitajSale();
    }
    async ucitajSale(){
        sale_niz=[];
        var g=new Grad();
        g=gradovi.find(g=>g.ime==document.getElementById("select_grad").value);
        if (g==null){
            return
        }
        document.getElementById("select_sala").options.length=0;
        await fetch(`https:localhost:5001/Sala/VratiSale/`+g.id,{
                method: "GET"
                }).then(p => {
                    p.json().then(data => {
                        data.forEach(sala => {
                            sale_niz.push(new Sala(sala.id,sala.ime,sala.kapacitet,sala.grad));
                            var opt = document.createElement("option");
                            opt.value = sala.ime;
                            opt.innerHTML = sala.ime;
                            document.getElementById("select_sala").appendChild(opt);
                        });
                        });
                    });
    }
    async obrisiSale() {
        if (sale_niz==[]){
            alert("Nema sala za brisanje.");
            return;
        }
        sale_niz=[];
        await fetch(`https:localhost:5001/Sala/ObrisiSale`,{
            method: "DELETE"
        })
        document.getElementById("select_sala").options.length=0;
    }
}