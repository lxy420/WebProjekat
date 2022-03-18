
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
await sala.ucitajSale();
if( koncert.getLen()>0)
    document.getElementById("button_kupi_kartu").disabled=false;
else
    document.getElementById("button_kupi_kartu").disabled=true;
async function setup(){
    await grad.ucitajGradove();
    await sala.setGradovi(grad.returnGradovi());
    await izvodjac.ucitajIzvodjace();
    await koncert.ucitajKoncerte();

    document.getElementById("button_dodaj_grad").onclick = (ev) => {grad.dodajGrad()};
    document.getElementById("button_obrisi_gradove").onclick = (ev) => {
        grad.obrisiGradove()
    };
    document.getElementById("select_grad").addEventListener("change",(e)=>{
        sala.setGradovi(grad.returnGradovi());
        sala.ucitajSale();
    })
    
    document.getElementById("button_dodaj_salu").onclick = (ev) => {
        sala.setGradovi(grad.returnGradovi());
        sala.dodajSalu()};
    document.getElementById("button_obrisi_sale").onclick = (ev) => {sala.obrisiSale()};
    
    document.getElementById("button_dodaj_izvodjaca").onclick = (ev) => {izvodjac.dodajIzvodjaca()};
    document.getElementById("button_obrisi_izvodjace").onclick = (ev) => {izvodjac.obrisiIzvodjace()};

    document.getElementById("button_kreiraj_koncert").onclick = (ev) => {
        koncert.setSale(sala.returnSale());
        koncert.kreirajKoncert()
        document.getElementById("button_kupi_kartu").disabled=false;
    };
    document.getElementById("button_obrisi_koncerte").onclick = (ev) => {
        koncert.obrisiKoncerte()
    document.getElementById("button_kupi_kartu").disabled=true;
    };

    document.getElementById("select_koncert").addEventListener("click",(e)=>{
        koncert.ucitajIzabraniKoncert(document.getElementById("select_koncert").value)
    })

    document.getElementById("button_kupi_kartu").onclick = (ev) => {
        s="sva sedista redom";
        const r=new Rezervacija(0,koncert.id,document.getElementById("input_telefon"),s);
    };

}

