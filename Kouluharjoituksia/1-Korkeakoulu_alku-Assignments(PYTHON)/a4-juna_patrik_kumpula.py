import json
import requests
junat =  requests.get("https://rata.digitraffic.fi/api/v1/train-locations/latest/")
junat_text = junat.text
junat_serialisoitu = json.loads(junat_text)

junat = sorted(junat_serialisoitu, key=lambda train :train['speed'], reverse=True)
for juna in junat:
    if (juna['speed'] == 0):
        speed = ",juna on pysähtynyt"
    else:
        speed = [",Vauhti on ", juna['speed'], "km/h"]

    print ("Junanumero:", juna['trainNumber'], ''.join(str(v) for v in speed), sep = "")