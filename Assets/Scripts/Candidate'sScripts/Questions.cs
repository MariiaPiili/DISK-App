using System.Collections.Generic;

public class Questions
{
    public List<string> ListOfQuestionsD = new List<string>{"Pidän siitä, että voin tehdä päätöksiä nopeasti.",
            "Olen luonnostani kilpailuhenkinen.",
            "Toimin mieluummin johtajana kuin seuraajana.",
            "Tavoittelen kunnianhimoisesti tavoitteitani.",
            "Olen valmis ottamaan riskejä.",
            "Toimin tehokkaasti paineen alla.",
            "Päätän nopeasti ja määrätietoisesti.",
            "En pelkää kohdata vaikeita tilanteita.",
            "Olen itsevarma ja suorasukainen.",
            "Pidän haasteista ja uuden oppimisesta.",
            "Haluan vaikuttaa muihin ihmisiin.",
            "Pyrin hallitsemaan tilanteita.",
            "Olen määrätietoinen ja suuntautunut tuloksiin.",
            "Pidän voimakkaasta kilpailusta.",
            "En pelkää konflikteja, jos ne ovat tarpeen.",
            "Teen asioita nopeasti ja tehokkaasti.",
            "Pidän kontrollista ja vallasta.",
            "Minulle on tärkeää saada asiat tehdyksi.",
            "Olen hyvin kunnianhimoinen.",
            "Toimin itsenäisesti ja nopeasti.",
            "Reagoin nopeasti muuttuviin tilanteisiin.",
            "En tarvitse jatkuvaa ohjausta.",
            "Pidän päätäntävaltaa tärkeänä.",
            "En epäröi sanoa mielipidettäni.",
            "Olen hyvin itseohjautuva."};
    public List<string> ListOfQuestionsI = new List<string>{"Pidän ihmisten kanssa työskentelemisestä.",
            "Olen helposti lähestyttävä.",
            "Olen puhelias ja iloinen.",
            "Kannustan muita aktiivisesti.",
            "Minulla on vahva sosiaalinen verkosto.",
            "Pidän esiintymisestä ja puhumisesta.",
            "Luon helposti uusia kontakteja.",
            "Toimin ryhmässä innostavasti.",
            "Haluan olla huomion keskipisteenä.",
            "Pidän muiden viihdyttämisestä.",
            "Olen avoin uusille kokemuksille.",
            "Kerron mielelläni tarinoita ja kokemuksia.",
            "Tykkään tehdä yhteistyötä toisten kanssa.",
            "Olen empaattinen ja ymmärtäväinen.",
            "Kannustan muita antamaan parhaansa.",
            "Pidän juhlista ja tapahtumista.",
            "Olen spontaani ja joustava.",
            "Minulla on positiivinen elämänasenne.",
            "Olen optimistinen ja energinen.",
            "Nautin muiden auttamisesta.",
            "Viestin mielelläni tunteita.",
            "Tykkään vaikuttaa ihmisten tunteisiin.",
            "Pidän keskustelusta ja ajatusten jakamisesta.",
            "Luotan ihmisiin helposti.",
            "Haluan tulla pidetyksi ja hyväksytyksi."};
    public List<string> ListOfQuestionsS = new List<string> { "Pidän vakaasta ja ennustettavasta ympäristöstä.",
            "Olen luotettava ja rauhallinen.",
            "Pyrin välttämään konflikteja.",
            "Olen hyvä kuuntelija.",
            "Toimin mieluummin taustalla kuin esillä.",
            "Olen kärsivällinen ja harkitseva.",
            "Haluan tukea muita heidän työssään.",
            "Pidän yhteistyöstä ja ryhmähengestä.",
            "Toimin tasaisesti eri tilanteissa.",
            "Pidän selkeistä ohjeista ja rutiineista.",
            "Minua motivoi turvallisuus ja jatkuvuus.",
            "Vältän turhaa kiirettä.",
            "Arvostan lojaaliutta ja pitkäaikaisia suhteita.",
            "Pidän asioiden tekemisestä loppuun asti.",
            "Kuuntelen ennen kuin reagoin.",
            "Olen tarkka ja huolellinen työssäni.",
            "Pyrin rauhaan ja tasapainoon.",
            "En pidä äkillisistä muutoksista.",
            "Pysyn rauhallisena painetilanteissa.",
            "Olen harkitseva päätöksissäni.",
            "Teen asiat mielelläni samalla tavalla joka kerta.",
            "Arvostan käytännöllisyyttä ja realismia.",
            "Toimin mieluummin rauhallisesti kuin nopeasti.",
            "Haluan säilyttää sovun muiden kanssa.",
            "Välitän muiden tunteista ja tarpeista."};
    public List<string> ListOfQuestionsC = new List<string> { "Arvostan tarkkuutta ja laatua.",
            "Tarkistan mieluummin asiat kahdesti.",
            "Pyrin toimimaan ohjeiden mukaan.",
            "Olen analyyttinen ja johdonmukainen.",
            "Teen päätökset huolellisesti.",
            "Pidän faktoihin perustuvasta päätöksenteosta.",
            "Olen huolellinen ja järjestelmällinen.",
            "En tee päätöksiä kevyesti.",
            "Arvostan selkeitä sääntöjä ja ohjeita.",
            "En pidä epävarmuudesta.",
            "Haluan ymmärtää asiat perusteellisesti.",
            "Keskityn yksityiskohtiin.",
            "Teen asioita oikein, en nopeasti.",
            "Pidän kirjaa tärkeistä asioista.",
            "Pyrin täsmällisyyteen kaikessa.",
            "Arvostan loogista ajattelua.",
            "Vältän virheitä hinnalla millä hyvänsä.",
            "Olen perfektionisti.",
            "Minua motivoi tietopohjainen arviointi.",
            "Haluan mitattavia tuloksia.",
            "Pidän itsenäisestä työstä ilman häiriöitä.",
            "En pidä kiireestä tai painostuksesta.",
            "En halua tehdä päätöksiä ilman riittäviä tietoja.",
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
