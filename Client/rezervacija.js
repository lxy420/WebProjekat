export class Rezervacija{
    constructor(id,koncertId,telefon,sediste){
        this.id=id;
        this.koncertId=koncertId;
        this.telefon=telefon;
        this.sediste=sediste;
    }
    async dodajRezervaciju(){
        await fetch(`https:localhost:5001/Rezervacija/DodajRezervaciju/`,{
            method: "POST",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify({
                koncertId:this.koncertId,
                telefon:this.telefon,
                sediste:this.sediste
            })
        }).then(p => {
            if (p.status == 400) {
                alert("Doslo je do greske.");
            }
        });
    }
};