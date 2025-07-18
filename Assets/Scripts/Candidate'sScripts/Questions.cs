using System.Collections.Generic;

public class Questions
{
    public List<string> ListOfQuestionsD = new List<string>{"Pid�n siit�, ett� voin tehd� p��t�ksi� nopeasti.",
            "Olen luonnostani kilpailuhenkinen.",
            "Toimin mieluummin johtajana kuin seuraajana.",
            "Tavoittelen kunnianhimoisesti tavoitteitani.",
            "Olen valmis ottamaan riskej�.",
            "Toimin tehokkaasti paineen alla.",
            "P��t�n nopeasti ja m��r�tietoisesti.",
            "En pelk�� kohdata vaikeita tilanteita.",
            "Olen itsevarma ja suorasukainen.",
            "Pid�n haasteista ja uuden oppimisesta.",
            "Haluan vaikuttaa muihin ihmisiin.",
            "Pyrin hallitsemaan tilanteita.",
            "Olen m��r�tietoinen ja suuntautunut tuloksiin.",
            "Pid�n voimakkaasta kilpailusta.",
            "En pelk�� konflikteja, jos ne ovat tarpeen.",
            "Teen asioita nopeasti ja tehokkaasti.",
            "Pid�n kontrollista ja vallasta.",
            "Minulle on t�rke�� saada asiat tehdyksi.",
            "Olen hyvin kunnianhimoinen.",
            "Toimin itsen�isesti ja nopeasti.",
            "Reagoin nopeasti muuttuviin tilanteisiin.",
            "En tarvitse jatkuvaa ohjausta.",
            "Pid�n p��t�nt�valtaa t�rke�n�.",
            "En ep�r�i sanoa mielipidett�ni.",
            "Olen hyvin itseohjautuva."};
    public List<string> ListOfQuestionsI = new List<string>{"Pid�n ihmisten kanssa ty�skentelemisest�.",
            "Olen helposti l�hestytt�v�.",
            "Olen puhelias ja iloinen.",
            "Kannustan muita aktiivisesti.",
            "Minulla on vahva sosiaalinen verkosto.",
            "Pid�n esiintymisest� ja puhumisesta.",
            "Luon helposti uusia kontakteja.",
            "Toimin ryhm�ss� innostavasti.",
            "Haluan olla huomion keskipisteen�.",
            "Pid�n muiden viihdytt�misest�.",
            "Olen avoin uusille kokemuksille.",
            "Kerron mielell�ni tarinoita ja kokemuksia.",
            "Tykk��n tehd� yhteisty�t� toisten kanssa.",
            "Olen empaattinen ja ymm�rt�v�inen.",
            "Kannustan muita antamaan parhaansa.",
            "Pid�n juhlista ja tapahtumista.",
            "Olen spontaani ja joustava.",
            "Minulla on positiivinen el�m�nasenne.",
            "Olen optimistinen ja energinen.",
            "Nautin muiden auttamisesta.",
            "Viestin mielell�ni tunteita.",
            "Tykk��n vaikuttaa ihmisten tunteisiin.",
            "Pid�n keskustelusta ja ajatusten jakamisesta.",
            "Luotan ihmisiin helposti.",
            "Haluan tulla pidetyksi ja hyv�ksytyksi."};
    public List<string> ListOfQuestionsS = new List<string> { "Pid�n vakaasta ja ennustettavasta ymp�rist�st�.",
            "Olen luotettava ja rauhallinen.",
            "Pyrin v�ltt�m��n konflikteja.",
            "Olen hyv� kuuntelija.",
            "Toimin mieluummin taustalla kuin esill�.",
            "Olen k�rsiv�llinen ja harkitseva.",
            "Haluan tukea muita heid�n ty�ss��n.",
            "Pid�n yhteisty�st� ja ryhm�hengest�.",
            "Toimin tasaisesti eri tilanteissa.",
            "Pid�n selkeist� ohjeista ja rutiineista.",
            "Minua motivoi turvallisuus ja jatkuvuus.",
            "V�lt�n turhaa kiirett�.",
            "Arvostan lojaaliutta ja pitk�aikaisia suhteita.",
            "Pid�n asioiden tekemisest� loppuun asti.",
            "Kuuntelen ennen kuin reagoin.",
            "Olen tarkka ja huolellinen ty�ss�ni.",
            "Pyrin rauhaan ja tasapainoon.",
            "En pid� �killisist� muutoksista.",
            "Pysyn rauhallisena painetilanteissa.",
            "Olen harkitseva p��t�ksiss�ni.",
            "Teen asiat mielell�ni samalla tavalla joka kerta.",
            "Arvostan k�yt�nn�llisyytt� ja realismia.",
            "Toimin mieluummin rauhallisesti kuin nopeasti.",
            "Haluan s�ilytt�� sovun muiden kanssa.",
            "V�lit�n muiden tunteista ja tarpeista."};
    public List<string> ListOfQuestionsC = new List<string> { "Arvostan tarkkuutta ja laatua.",
            "Tarkistan mieluummin asiat kahdesti.",
            "Pyrin toimimaan ohjeiden mukaan.",
            "Olen analyyttinen ja johdonmukainen.",
            "Teen p��t�kset huolellisesti.",
            "Pid�n faktoihin perustuvasta p��t�ksenteosta.",
            "Olen huolellinen ja j�rjestelm�llinen.",
            "En tee p��t�ksi� kevyesti.",
            "Arvostan selkeit� s��nt�j� ja ohjeita.",
            "En pid� ep�varmuudesta.",
            "Haluan ymm�rt�� asiat perusteellisesti.",
            "Keskityn yksityiskohtiin.",
            "Teen asioita oikein, en nopeasti.",
            "Pid�n kirjaa t�rkeist� asioista.",
            "Pyrin t�sm�llisyyteen kaikessa.",
            "Arvostan loogista ajattelua.",
            "V�lt�n virheit� hinnalla mill� hyv�ns�.",
            "Olen perfektionisti.",
            "Minua motivoi tietopohjainen arviointi.",
            "Haluan mitattavia tuloksia.",
            "Pid�n itsen�isest� ty�st� ilman h�iri�it�.",
            "En pid� kiireest� tai painostuksesta.",
            "En halua tehd� p��t�ksi� ilman riitt�vi� tietoja.",
            "Pyrin jatkuvaan parantamiseen.",
            "Teen kaiken harkiten ja vastuullisesti."};

    public string GetQuestion(int currentQuestion, int currentBlock)
    {
        switch (currentBlock)
        {
            case 0:
                return ListOfQuestionsD[currentQuestion];
            case 1:
                return ListOfQuestionsI[currentQuestion];
            case 2:
                return ListOfQuestionsS[currentQuestion];
            case 3:
                return ListOfQuestionsC[currentQuestion];
        }
        return "";
    }
}
