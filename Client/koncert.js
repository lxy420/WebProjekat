import { Sala } from "./sala.js";
import { Izvodjac } from "./izvodjac.js";

var koncerti_niz=[];
var sale_niz=[];
var izvodjaci_niz=[];
var odabranaSala=null;
var zauzeta=[];

export class Koncert{
    constructor(id,salaid,ime,datum,izvodjacid){
        this.id=id;
        this.salaid=salaid;
        this.ime=ime;
        this.datum=datum;
        this.izvodjacid=izvodjacid;
    }
    getKoncerti(){
        return koncerti_niz;
    }
    setSale(s){
        sale_niz=s;
    }
    setIzvodjace(i){
        izvodjaci_niz=i;
    }
    async kreirajKoncert(){
        if (document.getElementById("input_ime_koncerta").value=="" || document.getElementById("select_grad").value==""|| document.getElementById("select_sala").value==""|| document.getElementById("select_izvodjac").value=="" || document.getElementById("input_datum_vreme").value==""){
            alert("Popunite sva polja.");
            return
        }
        var id_sale=sale_niz.find(g=>g.ime==document.getElementById("select_sala").value).id;
        var id_izvodjac=izvodjaci_niz.find(g=>g.ime==document.getElementById("select_izvodjac").value).id;
        var datum_vreme=document.getElementById("input_datum_vreme").value;
        await fetch(`https:localhost:5001/Koncert/DodajKoncert/`+id_sale,{
            method: "POST",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify({
                ime:document.getElementById("input_ime_koncerta").value,
                salaid: id_sale,
                izvodjacid: id_izvodjac,
                date: datum_vreme
            })
        }).then(p => {
            if (p.status == 400) {
                alert("Koncert vec postoji.");
            }
            else if(p.status==200){
                alert("Koncert uspesno kreiran.");
            }
        }); 
        this.ucitajKoncerte();
    }
    async ucitajKoncerte(){
        koncerti_niz=[];
        var s=document.getElementById("select_koncert");
        document.getElementById("select_koncert").length=0;
        await fetch(`https:localhost:5001/Koncert/VratiKoncerte`,{
                method: "GET"
                }).then(p => {
                    p.json().then(data => {
                        data.forEach(i => {
                            koncerti_niz.push(new Koncert(i.id,i.salaid,i.ime));
                            const opt = document.createElement("option");
                            opt.value = i.ime;
                            opt.innerHTML = i.ime;
                            document.getElementById("select_koncert").appendChild(opt);
                        });
                        });
                    });
    }
    async obrisiKoncerte() {
        if (koncerti_niz==[]){
            alert("Nema koncerta za brisanje.");
            return;
        }
        koncerti_niz=[];
        await fetch(`https:localhost:5001/Koncert/ObrisiKoncerte`,{
            method: "DELETE"
        }).then(p => {
            if (p.ok) {
               // alert(p.status);
                console.log(p.statusText);
            }
        });
        document.getElementById("select_koncert").options.length=0;
    }
    async ucitajIzabraniKoncert(ime){
        var k=koncerti_niz.find(g=>g.ime==ime);
        console.log(k.id);
        await fetch(`https:localhost:5001/Koncert/ucitajIzabraniKoncert/`+k.id,{
                method: "GET"
                }).then(response => response.json())
                .then(data => {
                    odabranaSala=new Sala(data.id,data.ime,data.kapacitet);
                });

        await fetch(`https:localhost:5001/Rezervacija/VratiZauzeta/`+k.id,{
            method: "GET"
            }).then(p => {
                p.json().then(data => {
                    data.forEach(i => {
                        zauzeta.push(i.sediste);
                    });
                });
            });
        odabranaSala.drawSala(zauzeta); //i onda samo tu jos to
        
        await fetch(`https:localhost:5001/Koncert/vratiKoncert/`+k.id,{
            method: "GET"
            }).then(response => response.json())
            .then(data => {
                //var odabraniKoncert=new Koncert(data.id,data.salaId,data.ime,data.date,data.izvodjacId);
               // console.log(odabraniKoncert);
               document.getElementById("label_koncert_ime").innerHTML="ime: "+koncerti_niz.find(g=>g.id==data.id).ime;
               document.getElementById("label_koncert_datum").innerHTML="datum/vreme: "+data.date;
               document.getElementById("label_koncert_izvodjac").innerHTML="izvodjac: "+izvodjaci_niz.find(s=>s.id==data.izvodjacId).ime;
               document.getElementById("label_koncert_sala").innerHTML="sala: "+sale_niz.find(s=>s.id==data.salaId).ime;
            });

    }
    getLen(){
        return koncerti_niz.length;
    }
}