
import {Forma} from "./forma.js";
import {Grad} from "./grad.js";
import {Sala} from "./sala.js";
import {Izvodjac} from "./izvodjac.js";
import {Koncert} from "./koncert.js";
import {Rezervacija} from "./rezervacija.js";


const forma = new Forma();
const grad=new Grad();
const sala=new Sala();
const izvodjac=new Izvodjac();
const koncert=new Koncert();

await setup();

document.getElementById("button_kupi_kartu").disabled=true;

async function setup(){
    await grad.ucitajGradove();
    await sala.setGradovi(grad.returnGradovi());
    await izvodjac.ucitajIzvodjace();
    await koncert.ucitajKoncerte();
    await sala.ucitajSale();
}

//events

document.getElementById("button_dodaj_grad").onclick = async (ev) => {await grad.dodajGrad()};
document.getElementById("button_obrisi_gradove").onclick = async (ev) => {
    await grad.obrisiGradove()
};
document.getElementById("select_grad").addEventListener("change", async (e)=>{
    await sala.setGradovi(grad.returnGradovi());
    await sala.ucitajSale();
})

document.getElementById("button_dodaj_salu").onclick =async (ev) => {
    await sala.setGradovi(grad.returnGradovi());
    await sala.dodajSalu()};
document.getElementById("button_obrisi_sale").onclick =async (ev) => {await sala.obrisiSale()};

document.getElementById("button_dodaj_izvodjaca").onclick = async (ev) => {await izvodjac.dodajIzvodjaca()};
document.getElementById("button_obrisi_izvodjace").onclick = async (ev) => {await izvodjac.obrisiIzvodjace()};

document.getElementById("button_kreiraj_koncert").onclick = async (ev) => {
    await koncert.setSale(sala.returnSale());
    await koncert.setIzvodjace(izvodjac.returnIzvodjace());
    await koncert.kreirajKoncert()
};
document.getElementById("button_obrisi_koncerte").onclick = async (ev) => {
    await koncert.obrisiKoncerte()
};

document.getElementById("select_koncert").addEventListener("click",async (e)=>{
    if (koncert.getKoncerti().length==0)
        return
    await koncert.setSale(sala.returnSale());
    await koncert.setIzvodjace(izvodjac.returnIzvodjace());
    await koncert.ucitajIzabraniKoncert(document.getElementById("select_koncert").value)
})

document.getElementById("input_telefon").addEventListener("change",(e)=>{
    var ss=sala.returnSelektovanaSedista();
    if(document.getElementById("input_telefon").value!="" && ss.length>0)
        document.getElementById("button_kupi_kartu").disabled=false;
    else
        document.getElementById("button_kupi_kartu").disabled=true;
});

document.getElementById("button_kupi_kartu").onclick =async (ev) => {
    var ss=sala.returnSelektovanaSedista();
    for(var i=0;i<ss.length;i++){
        var r=new Rezervacija(0,koncert.getKoncerti().find(x=>x.ime==document.getElementById("select_koncert").value).id,document.getElementById("input_telefon").value,ss[i]);
        await r.dodajRezervaciju();
    }
    alert("Rezervacija uspesna");
    location.reload();
};
