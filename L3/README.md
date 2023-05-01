# Lab3

## 1 užduoties dalis (4 balai):
* Pateikite rekursinį uždavinio sprendimo algoritmą (rekursinis sąryšis su paaiškinimais), bei realizuokite programinį kodą sprendžiantį nurodytą uždavinį (rekursinis sprendimas netaikant dinaminio programavimo).
* Pritaikykite dinaminio programavimo metodologiją pateiktam uždaviniui (pateikti paaiškinimą), bei realizuokite programinį kodą sprendžiantį nurodytą uždavinį (taikant dinaminį programavimą).
* Atlikite realizuotų programinių kodų analizę ir apskaičiuokite įverčius „iš viršaus“ ir „iš apačios“. Atlikite našumo analizę (skaičiuojant programos vykdymo laiką arba veiksmų skaičių) ir patikrinkite, ar apskaičiuotas metodo asimptotinis sudėtingumas atitinka eksperimentinius rezultatus.

## 2-3 užduotys (6 balai):
* Atlikite pateiktų procedūrų lygiagretinimą.
* Įvertinkite teorinį nelygiagretintų ir lygiagretintų procedūrų sudėtingumą.
* Atlikite realizuotų programinių kodų analizę ir apskaičiuokite įverčius „iš viršaus“ ir „iš apačios“. Atlikite našumo analizę (skaičiuojant programos vykdymo laiką arba veiksmų skaičių) ir patikrinkite, ar apskaičiuotas metodo asimptotinis sudėtingumas atitinka eksperimentinius rezultatus.
* 2 uždavinys - 3 balai / 3 uždavinys - 3 balai

## Gautos užduotys
1. Duota matrica NxN. Reikia rasti didžiausią K, kad submatricos KxK visi elementai būtų lygūs.
```
                | 1 3 3 |
Pvz. Duota: A = | 2 3 3 | Atsakymas 2, submatrica sudaryta iš trejetų.
                | 1 2 4 |
```

2. 
```C#
public static long methodToAnalysis (int[] arr)
{
    long n = arr.Length;
    long k = n; 

    if(arr[0] < 0) 
    {
        for (int i = 0; i < n; i++)
        {
            if (i > 0)
            {
                for (int j = 0; j < n; j++)
                {
                    k -= 2;
                }
            }
        }
    }

    return k;
}
```

3. 
```C#
public static long methodToAnalysis (int n, int[] arr)
{
    long k = 0;
    for (int i = 1; i < n; i++)
    {
        k += k;
        k += FF10(i, arr);
        k += FF10(i / i, arr);
    }
    return k;
}

public static long FF10(int n, int[] arr)
{
    if(n > 1 && arr.Length > n)
    {
        return FF10(n - 2, arr) + FF10(n / n, arr);
    }

    return n;
}
```