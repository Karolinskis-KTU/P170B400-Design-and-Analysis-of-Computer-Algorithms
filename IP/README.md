# IP

1. **Dalis.** (~3 balai). Realizuoti programą, kuri individualiai problemai pateiktų optimalų sprendinį. Nustatyti, prie kokios duomenų apimties sprendinį pavyksta rasti jei programos vykdymo laikas negali būti ilgesnis nei 10 sek.
2. **Dalis.** (~2 balai). Realizuoti programą, kuri individualios problemos rezultatą pateiktų priimant "lokaliai geriausią" spendinį (pvz. esant keliems pasirinkimams keliauti į skirtingas viršūnes, visuomet renkamasi: pigiausias ar trumpiausias ar ... kelias)
3. **Dalis.** (~5 balai). Realizuoti programą, kuri pateiktų sprendinį taikant Genetinio Optimizavimo metodą. Programa pateikti rezultatą turi ne ilgiau, nei per 60 sek.

**Bendra:**

* Darbo ataskaitoje turi būti pateikta:
  * apskaičiuotas asimptotinis programos vykdymo laiko sudėtingumas (esant rekursiniams metodams, turi būti suformuojama rekurentinė lygtis);
  * realizuotų programų (sudaryto algoritmo konkrečiam uždaviniui) abstraktus aprašas („pseudo“ kodas ar „workflow“ diagrama);
  * skirtingų metodų rezultatų analizė uždavinio gerumo ir vykdymo laiko prasme esant kelioms skirtingoms pradinėms sąlygoms.
  * pateikti rekomenduojamus genetinio optimizavimo parametrus užduoties sprendimui (populiacijos dydis, elito kiekis, ...). Pateikti analizės rezultatus, kaip buvo parinkti rekomendaciniai parametrai, t. y. analizės rezultatuose turi pasimatyti, jog per maksimalų programos vykdymo laiką, tikėtina, jog tikslo funkcija įgaus didžiausią reikšmę.
  * marštutai, sudaryti analizuojant atksirus atvejus atvaizduojami grafiškai.
* Kelionės pradžią turi būti galima nurodyti bet kurią vietą ar miestą (priklausomai nuo individualios sąlygos) iš pateiktų duomenų.
* Programavimo kalba: bet kuri, išskyrus Python.

---

Faile places_data.xlsx pateikta informacija apie miestus (įskaitant jų gerumo įvertį) ir kelius tarp jų (kelionės laikas ir kaina) (2, 3 lentelė).
Tikslas: kaip galima geresnio (vertinama pagal aplankytų miestų gerumo įverčius) maršruto sudarymas kai:
* kelionės pradžios ir pabaigos vieta sutampa (su grįžimu atgal);
* bendras kelionės laikas negali viršyti 48 val.;
* tą patį miestą galima aplankyti kelis kartus, tačiau jo gerumo įvertis sumuojamas tik vieną kartą.