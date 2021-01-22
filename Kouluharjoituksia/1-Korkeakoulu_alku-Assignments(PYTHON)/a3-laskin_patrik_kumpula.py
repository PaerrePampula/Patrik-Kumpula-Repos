arvoa = ""
arvob = ""
arvot = []
def laskin():
    while True:
        def yhteenlasku(x, y):
            print(x + y)
        def vähennyslasku(x, y):
            print(x - y)
        def kertolasku(x, y):
            print(x*y)
        def jakolasku(x, y):
            print(x/y)
        def intvaifloat(x):
            if x == int(x):
                x = int(x)
            else:
                x = float(x)
        valinta = input("Valitse haluamasi lasku valitsemalla laskun symboli (+,-,*,/ tai 'poistu')")
        if (valinta == "+" or valinta == "-" or valinta == "*" or valinta == "/" or valinta == "poistu"):
            if(valinta == "poistu"):
                print("Näkemiin")
                break
            for x in range(2):
                arvo = float(input("kirjoita arvo"))
                intvaifloat(arvo)
                arvot.append(arvo)
            if (valinta == "+"):
                yhteenlasku(arvot[0],arvot[1])
            if (valinta == "-"):
                vähennyslasku(arvot[0],arvot[1])
            if (valinta == "*"):
                kertolasku(arvot[0],arvot[1])
            if (valinta == "/"):
                if not (arvot[1] == int(0)):
                    jakolasku(arvoa, arvob)
                else:
                    print("nollalla ei voida jakaa")
        else:
            print("valinta on väärin")
            laskin()
laskin()