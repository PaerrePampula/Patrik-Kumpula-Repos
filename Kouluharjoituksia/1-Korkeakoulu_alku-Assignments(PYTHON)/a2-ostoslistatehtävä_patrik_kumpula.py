import json
try:
    tiedosto = open("ostoslista.json" , "r")
    serialisoitu_ostoslista = tiedosto.read()
    ostoslista = json.loads(serialisoitu_ostoslista)
except FileNotFoundError:
    ostoslista = []
kauppa = ["Maito", "Leipä", "Sokeri"]
menu = 1
def lisäätuotemenu():
    print ("Kaupasta löytyy:")
    for x in kauppa:
        print(x, ",", sep = (""))
    print("Valitse tuote kirjoittamalla sen nimi")
    tuotelisä = input("")
    if tuotelisä in kauppa:
        ostoslista.append(tuotelisä)
        kauppa.remove(tuotelisä)
        print("Ostoslistallasi on nyt", tuotelisä)
    else:
        print("'Sori, me ei myydä", tuotelisä, "'")
def näytäostoslista():
    if len(ostoslista) == 0:
        print("Ostoslistasi on tyhjä!")
    else:
        print("Ostoslistalla on seuraavat tuotteet:")
        for x in ostoslista:
            print(x, ",", sep = (""))

while True:
        valinta = input("Valitse yksi jos haluat nähdä ostoslistan" "\n" "Valitse kaksi, jos haluat lisätä listaan tuotteen" "\n" "Valitse kolme, jos haluat poistua." "\n")
        if valinta == ("1" or "1."):
            näytäostoslista()
        elif valinta == ("2" or "2."):
            if len(kauppa) == 0:
                print("Kauppa on tyhjä! :(")
            else:
                lisäätuotemenu()
        elif valinta == ("3" or "3."):
            input("Näkemiin!")
            serialisoitu_ostoslista = json.dumps(ostoslista)
            tiedosto = open("ostoslista.json" , "w+")
            tiedosto.write(serialisoitu_ostoslista)
            tiedosto.close()
            break
        else:
            print ("Vastaa 1-3")
