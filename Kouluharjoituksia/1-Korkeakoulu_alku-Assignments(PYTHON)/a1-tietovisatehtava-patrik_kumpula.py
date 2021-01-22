import random #random moduulii listan random valintaa varten
annettuja_vastauksia = 0 #sitä sun tätä muuttujia jota tarvitaan, varmistetaan että ne ovat aluksi nolla
oikeat_vastaukset = 0
väärät_vastaukset = 0
list = ["Juu", "Oikein", "Takuulla oikein", "Ihan oikein", "Ehdottomasti"] #lista kaikelaisia pikkukiljahduksia jos vastaat oikein
def oikein():##Oikein ja väärin metodit
    global oikeat_vastaukset
    print("\n",random.choice(list),"\n")   #Heittää randomilla jonkun hyvän letkautuksen listasta
    oikeat_vastaukset += 1
def vaarin():

    global väärät_vastaukset
    print("\n" "VÄÄÄÄRIN!!!" "\n")
    väärät_vastaukset +=1

def kysykyssäri(): #Varsinainen kyssärinkysyminen
    global vas
    global oikeavastaus
    if annettuja_vastauksia == 0:
        oikeavastaus = 1
        print ("Eräs viisas mies kerran kysyi: \
        'What is the airspeed velocity of an unladen swallow?'", "\n" "Onko vastaus..." "\n"
        "1)10-11m/s " "\n"
        "2)'What do you mean? African or European swallow?' " )
        vas = input()
        vastattu(oikeavastaus, vas)
    elif annettuja_vastauksia == 1:
        oikeavastaus = 2
        print ("'What is the answer to life, universe and everything?'", "\n" 
        "1)Jeesus?" "\n"
        "2)42" "\n"
        "3)Ei mikään ylläolevista")
        vas = input("")
        vastattu(oikeavastaus, vas)
    elif annettuja_vastauksia == 2:
        print ("Kuuluuko ananas bitsuun?" "\n"
        "1)Joo" "\n"
        "2)EI!!!!!")
        oikeavastaus = 1
        vas = input()
        vastattu(oikeavastaus, vas)
    elif annettuja_vastauksia == 3:
        print ("Onko sukat ja sandaalit tyylivirhe?" "\n"
        "1)Ei missään nimessä!" "\n"
        "2)Tottakai?")
        oikeavastaus = 1
        vas = input()
        vastattu(oikeavastaus, vas)
    elif annettuja_vastauksia == 4:
        print("Kuuluuko pitsa kuitenkin ananakseen?" "\n"
        "1)No juu" "\n"
        "2)Ei missään tapauksessa" "\n"
        "3)Siitä ei puhuta")
        oikeavastaus = 3
        vas = input()

        vastattu(oikeavastaus, vas)

def vastattu(oikeavastaus, vas): #vastauksen perusteella päätellään oliko se oikein vai väärin
    try:
        global annettuja_vastauksia
        annettuja_vastauksia +=1
        if int(vas) == int(oikeavastaus):
            oikein()
            aloita()
        else: 
            vaarin()
            aloita()
    except ValueError:  #Napataan tässä ne kaikki vastaukset jotka sattumoisin ei ole kokonaislukuja ettei koko juttu aina kaadu jos ei vastaa numerolla
        print("kirjoita aina numero")
        input()
def aloita(): #koko laitos alkaa tällä metodilla joka pyydetään tuolla alhaalla suorittamaan

    if annettuja_vastauksia < 5:
        kysykyssäri()
    else:
        print("Sait vastauksista", (int(oikeat_vastaukset/5*100)) ,"%", "Oikein!") 
        input("Paina enteriä jatkaaksesi...") #Täällä päätetään tämä tuikitärkeä tietovisa ja laskeskellaan kuinka monta prosenttia vastasimme oikein

print("Valmistaudu maailman vaativampaan tietovisaan!")
aloita()