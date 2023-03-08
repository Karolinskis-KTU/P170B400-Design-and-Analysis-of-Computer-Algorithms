# Lab2

## 1 užduoties dalis (4 balai):
Pateiktiems programinio kodo metodams "methodToAnalysis(...)" (gautiems atlikus užduoties pasirinkimo testą):
* atlikite programinio kodo analizę, bei sudarykite rekurentinę lygtį. jei metodas neturi vidinių rekursinių kreipinių, apskaičiuokite pateikto metodo asimptotinį sudėtingumą. Jei metodo sudėtingumas priklauso nuo duomenų pateikiamų per parametrus - apskaičiuokite įverčius "iš viršaus" ir "iš apačios" (2 balai).
* Metodams, kurie turi rekurentinių kreipinių išspręskite rekurentinę lygtį apskaičiuodami jos asimptotinį sudėtingumą (1 balas).
* Atlikti eksperimentinį tyrimą (našumo testus: vykdymo laiką ir veiksmų skaičių) ir patikrinkite ar apskaičiuotas metodo asimptotinis sudėtingumas atitinka eksperimentinius rezultatus. Jei pateikto metodo asimptotinis sudėtingumas priklauso nuo duomenų, atitinkamai atliekant analizę reikia parinkti tokias testavimo duomenų imtis, kad rezultatai atspindėtų įvertinimus iš viršaus ir iš apačios (1 balas).

## 2 užduoties dalis (6 balai):
* Pateikite rekursinį uždavinio sprendimo algoritmą (rekursinis sąryšis su paaiškinimais), bei realizuokite programinį kodą sprendžiantį nurodytą uždavinį (rekursinis sprendimas netaikant dinaminio programavimo).
* Pritaikyte dinaminio programavimo metodologiją pateiktam uždaviniui (pateikti paaiškinimą), bei realizuokite programinį kodą sprendžiantį nurodytą uždavinį (taikant dinaminį programavimą).
* Atlikite realizuotų programinių kodų analizę ir apskaičiuokite įverčius "iš viršaus" ir "iš apačios". Atlikite našumo analizę (skaičiuojant programos vykdymo laiką arba veiksmų skaičių) ir patikrinkite, ar apskaičiuotas metodo asimptotinis sudėtingumas atitinka eksperimentinius rezultatus.

## Gautos užduotys
1. 
```C#
public static long methodToAnalysis(int[] arr)
{
    long n = arr.Length;
    long k = n;
    for (int i = 0; i < n*2; i++)
    {
        for(int j = 0; j < n/2; j++)
        {
            k -=2;
        }
    }
    return k;
}
```

2. 
```C#
public static long methodToAnalysis(int n)
{
    long k = 0;
    int[] arr = new int[n];
    Random randNum = new Random();
    for (int i = 0; i < n; i++)
    {
        arr[i] = randNum.Next(0, n);
        k += arr[i] + FF2(i, arr);
    }
    return k;
}

public static long FF2(int n, int [] arr)
{
    if(n > 0 && arr.Length > n && arr[n] > 0)
    {
        return FF2(n - 1, arr) + FF2(n - 3, arr);
    }
    return n;
}
```
3. 
Logistikos įmonė turi nuvežti krovinį. Veždamas nuo pakrovimo iki iškrovimo sandėlio, vežėjas gali aplankyti n sandėlių, pažymėtų numeriais nuo 1 iki n. Vežėjas gali judėti tik didesniu numeriu pažymėto sandėlio link. Duotas kainų masyvas C, kur C(i,j) reikšmė nurodo, kiek kainuoja nuvažiuoti nuo i-tojo sandėlio iki j-tojo (įvertinami poilsio mokesčiai, kitos sąnaudos). Žinoma, kad C(i,j) = 0, ir nertinamas grįžimas atgal C(i,j) = ∞, jei i > j. Reikia rasti pigiausiai kainuojančių sandėlių seką.

