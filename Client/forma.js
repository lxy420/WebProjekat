
export class Forma{
    constructor(){
        this.drawForm();
      
    }
    drawForm(){
        const div_form = document.createElement("div");
        div_form.setAttribute("id","div_form")
        document.body.append(div_form);

        const div_koncert = document.createElement("div");
        div_koncert.setAttribute("id","div_koncert")
        div_form.append(div_koncert);

        //ime koncerta
        const label_ime_koncerta = document.createElement("label");
        label_ime_koncerta.innerHTML = "Ime Koncerta: ";
        div_koncert.appendChild(label_ime_koncerta);
        div_koncert.appendChild(document.createElement("br"));

        const input_ime_koncerta = document.createElement("input");
        input_ime_koncerta.setAttribute("id","input_ime_koncerta")
        input_ime_koncerta.setAttribute("placeholder","Ime koncerta")
        div_koncert.appendChild(input_ime_koncerta);

        //grad
        div_koncert.appendChild(document.createElement("br"));

        const label_grad = document.createElement("label");
        label_grad.innerHTML = "Grad: ";
        div_koncert.appendChild(label_grad);
        div_koncert.appendChild(document.createElement("br"));

        const select_grad = document.createElement("select");
        select_grad.setAttribute("id","select_grad");
        div_koncert.appendChild(select_grad);

        const button_obrisi_gradove = document.createElement("button");
        button_obrisi_gradove.innerHTML = "X";
        button_obrisi_gradove.setAttribute("id","button_obrisi_gradove");
        div_koncert.appendChild(button_obrisi_gradove);
        div_koncert.appendChild(document.createElement("br"));

        const label_dodaj_grad = document.createElement("label");
        label_dodaj_grad.innerHTML = "Dodaj grad: ";
        div_koncert.appendChild(label_dodaj_grad);
        div_koncert.appendChild(document.createElement("br"));

        const input_grad = document.createElement("input");
        input_grad.setAttribute("id","ime_grada")
        input_grad.setAttribute("placeholder","Ime grada")
        div_koncert.appendChild(input_grad);

        const button_dodaj_grad = document.createElement("button");
        button_dodaj_grad.innerHTML = "dodaj grad";
        button_dodaj_grad.setAttribute("id","button_dodaj_grad");
        div_koncert.appendChild(button_dodaj_grad);

        //sala
        div_koncert.appendChild(document.createElement("br"));

        const label_sala = document.createElement("label");
        label_sala.innerHTML = "Sala: ";
        div_koncert.appendChild(label_sala);
        div_koncert.appendChild(document.createElement("br"));

        const select_sala = document.createElement("select");
        select_sala.setAttribute("id","select_sala");
        div_koncert.appendChild(select_sala);

        const button_obrisi_sale = document.createElement("button");
        button_obrisi_sale.innerHTML = "X";
        button_obrisi_sale.setAttribute("id","button_obrisi_sale");
        div_koncert.appendChild(button_obrisi_sale);
        div_koncert.appendChild(document.createElement("br"));

        const label_dodaj_salu = document.createElement("label");
        label_dodaj_salu.innerHTML = "Dodaj salu: ";
        div_koncert.appendChild(label_dodaj_salu);
        div_koncert.appendChild(document.createElement("br"));

        const input_sala_ime = document.createElement("input");
        input_sala_ime.setAttribute("placeholder","Ime sale")
        input_sala_ime.setAttribute("id","ime_sale")
        div_koncert.appendChild(input_sala_ime);
        div_koncert.appendChild(document.createElement("br"));

        const input_sala_kapacitet = document.createElement("input");
        input_sala_kapacitet.setAttribute("placeholder","Kapacitet sale")
        input_sala_kapacitet.setAttribute("id","kapacitet_sale")
        input_sala_kapacitet.type="number";
        input_sala_kapacitet.setAttribute("min",1);
        input_sala_kapacitet.setAttribute("max",1000);
        div_koncert.appendChild(input_sala_kapacitet);
        div_koncert.appendChild(document.createElement("br"));
       
    
        const button_dodaj_salu = document.createElement("button");
        button_dodaj_salu.setAttribute("id","button_dodaj_salu")
        button_dodaj_salu.innerHTML = "dodaj salu";
        div_koncert.appendChild(button_dodaj_salu);

        //izvodjaci
        div_koncert.appendChild(document.createElement("br"));

        const label_odabir_izvodjaca = document.createElement("label");
        label_odabir_izvodjaca.innerHTML = "Odabir izvodjaca: ";
        div_koncert.appendChild(label_odabir_izvodjaca);
        div_koncert.appendChild(document.createElement("br"));

        const select_izvodjac = document.createElement("select");
        select_izvodjac.setAttribute("id","select_izvodjac");
        div_koncert.appendChild(select_izvodjac);
        
        const button_obrisi_izvodjace = document.createElement("button");
        button_obrisi_izvodjace.innerHTML = "X";
        button_obrisi_izvodjace.setAttribute("id","button_obrisi_izvodjace");
        div_koncert.appendChild(button_obrisi_izvodjace);

        div_koncert.appendChild(document.createElement("br"));

        const label_dodaj_izvodjaca = document.createElement("label");
        label_dodaj_izvodjaca.innerHTML = "Dodaj izvodjaca: ";
        div_koncert.appendChild(label_dodaj_izvodjaca);
        div_koncert.appendChild(document.createElement("br"));

        const input_izvodjac_ime = document.createElement("input");
        input_izvodjac_ime.setAttribute("placeholder","Ime");
        input_izvodjac_ime.setAttribute("id","input_izvodjac_ime");
        div_koncert.appendChild(input_izvodjac_ime);

        div_koncert.appendChild(document.createElement("br"));

        const input_izvodjac_prezime = document.createElement("input");
        input_izvodjac_prezime.setAttribute("placeholder","Prezime")
        input_izvodjac_prezime.setAttribute("id","input_izvodjac_prezime")
        div_koncert.appendChild(input_izvodjac_prezime);

        div_koncert.appendChild(document.createElement("br"));

        const input_izvodjac_instrument = document.createElement("input");
        input_izvodjac_instrument.setAttribute("placeholder","Instrument")
        input_izvodjac_instrument.setAttribute("id","input_izvodjac_instrument")
        div_koncert.appendChild(input_izvodjac_instrument);

        const button_dodaj_izvodjaca = document.createElement("button");
        button_dodaj_izvodjaca.innerHTML = "dodaj izvodjaca";
        button_dodaj_izvodjaca.id = "button_dodaj_izvodjaca";
        div_koncert.appendChild(button_dodaj_izvodjaca);
        div_koncert.appendChild(document.createElement("br"));

       
        //datum
        const label_datum_vreme = document.createElement("label");
        label_datum_vreme.innerHTML = "Datum/Vreme: ";
        div_koncert.appendChild(label_datum_vreme);
        div_koncert.appendChild(document.createElement("br"));

        const input_datum_vreme = document.createElement("input");
        input_datum_vreme.setAttribute("id","input_datum_vreme")
        input_datum_vreme.type="datetime-local";
        div_koncert.appendChild(input_datum_vreme);
        div_koncert.appendChild(document.createElement("br"));
        div_koncert.appendChild(document.createElement("br"));

        //kretiraj koncert button
         
        const button_kreiraj_koncert = document.createElement("button");
        button_kreiraj_koncert.setAttribute("id","button_kreiraj_koncert");
        button_kreiraj_koncert.innerHTML = "kreiraj koncert";
        div_koncert.appendChild(button_kreiraj_koncert);
        div_koncert.appendChild(document.createElement("br"));
        div_koncert.appendChild(document.createElement("br"));


       //odabir

        const label_odaberi_koncert = document.createElement("label");
        label_odaberi_koncert.innerHTML = "Odaberi koncert: ";
        div_koncert.appendChild(label_odaberi_koncert);
        div_koncert.appendChild(document.createElement("br"));

        const select_koncert = document.createElement("select");
        select_koncert.setAttribute("id","select_koncert");
        div_koncert.appendChild(select_koncert);

        const button_obrisi_koncerte = document.createElement("button");
        button_obrisi_koncerte.setAttribute("id","button_obrisi_koncerte");
        button_obrisi_koncerte.innerHTML = "X";
        div_koncert.appendChild(button_obrisi_koncerte);
        div_koncert.appendChild(document.createElement("br"));

        const input_telefon = document.createElement("input");
        input_telefon.setAttribute("placeholder","Telefon");
        input_telefon.setAttribute("id","input_telefon");
        input_telefon.setAttribute("type","number");
        input_telefon.setAttribute("min","0");
        input_telefon.setAttribute("max","1000000000");
        div_koncert.appendChild(input_telefon);

        const button_kupi_kartu = document.createElement("button");
        button_kupi_kartu.setAttribute("id","button_kupi_kartu");
        button_kupi_kartu.innerHTML = "kupi kartu";
        div_koncert.appendChild(button_kupi_kartu);
        //button_kupi_kartu.disabled=true;
        div_koncert.appendChild(document.createElement("br"));

        const div_koncert_info = document.createElement("div");
        div_koncert_info.setAttribute("id","div_koncert_info")
        div_koncert.appendChild(div_koncert_info);
        //button_kupi_kartu.disabled=true;

        const label_koncert_ime = document.createElement("label");
        label_koncert_ime.setAttribute("id","label_koncert_ime");
        div_koncert_info.appendChild(label_koncert_ime);
        div_koncert_info.appendChild(document.createElement("br"));

        const label_koncert_datum = document.createElement("label");
        label_koncert_datum.setAttribute("id","label_koncert_datum");
        div_koncert_info.appendChild(label_koncert_datum);
        div_koncert_info.appendChild(document.createElement("br"));
        
        const label_koncert_izvodjac = document.createElement("label");
        label_koncert_izvodjac.setAttribute("id","label_koncert_izvodjac")
        div_koncert_info.appendChild(label_koncert_izvodjac);
        div_koncert_info.appendChild(document.createElement("br"));

        const label_koncert_sala= document.createElement("label");
        label_koncert_sala.setAttribute("id","label_koncert_sala")
        div_koncert_info.appendChild(label_koncert_sala);
        div_koncert_info.appendChild(document.createElement("br"));

    }
}