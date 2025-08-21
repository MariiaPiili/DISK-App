using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultsController : MonoBehaviour
{
    public CandidateController CandidateController;
    public CandidatesManager CandidatesManager;
    public ChatGPTService ChatGPTService;

    public Slider[] ProgressSliders;
    public TextMeshProUGUI[] ProgressTexts;
    public Image[] BlockImages;
    public Sprite OrdinarySprite;
    public Sprite HighlightedSprite;
    public TextMeshProUGUI MaxTypeText;
    public TextMeshProUGUI GPTDescriptionText;
    public Button ConfirmButton;     

    private async void OnEnable()
    {
        ConfirmButton.interactable = false;

        var candidate = CandidateController.Candidate;
        var results = new[] { candidate.DAmount, candidate.IAmount, candidate.SAmount, candidate.CAmount };
        int maxIndex = 0;

        for (int i = 0; i < results.Length; i++)
        {
            ProgressSliders[i].value = (results[i] - 25f) / 100f;
            ProgressTexts[i].text = results[i].ToString();
            BlockImages[i].sprite = OrdinarySprite;
            if (results[i] > results[maxIndex]) maxIndex = i;
        }
        BlockImages[maxIndex].sprite = HighlightedSprite;

        string[] types = { "D - Dominanssi", "I – Vaikuttaminen", "S – Vakaa tyyli", "C – Tunnollisuus" };
        MaxTypeText.text = types[maxIndex];

        string prompt =
$"D = {results[0]}, I = {results[1]}, S = {results[2]}, C = {results[3]}. " +
"Olet henkilöstöpäällikkö, jolla on psykologinen koulutus. Tehtäväsi on laatia ammatillinen ja myönteinen henkilöstökuvaus ehdokkaasta DISC-mallin perusteella.\n" +
"TOIMINTAOHJE:\n" +
"1) Aloita aina järjestämällä annetut profiilit (D, I, S, C) niiden pistemäärien perusteella suurimmasta pienimpään.Käytä tätä järjestystä koko kuvauksen ajan äläkä koskaan käytä oletusjärjestystä D, I, S, C.\n" +
"2) Varmista, että ensimmäinen käsiteltävä profiili on aina se, jolla on korkein pistemäärä, ja viimeinen se, jolla on matalin.\n" +
"3) Määritä kullekin profiilille voimakkuustaso pistehaarukan mukaan: 105–125 = erittäin vahvasti kehittynyt; 85–104 = selkeästi kehittynyt; 65–84 = kohtalaisesti kehittynyt; 25–64 = heikosti kehittynyt.\n" +
"4) Käytä alla olevaa FRAASISANASTOA valitun profiilin ja voimakkuustason mukaan. Muokkaa lauseet luontevaksi kuvaukseksi ehdokkaasta (kolmannessa persoonassa).\n" +
"5) Ensimmäinen (vahvin) profiili saa pisimmän ja yksityiskohtaisimman kuvauksen, seuraavat lyhyemmät.\n" +
"6) Päätä tekstin myönteisellä yhteenvedolla: millaisessa ympäristössä ehdokas toimii parhaiten ja mitä hyötyä hän tuo tiimille.\n" +
"7) Älä mainitse pisteitä tai laskentaa.\n" +
"8) Käytä vain annettuja tuloksia ja tietoja. Älä lisää esimerkkejä tai yksityiskohtia, joita ei ole suoraan annettu.\n" +
"9) Pituus: enintään 800 merkkiä, yhtenäinen kappale.\n" +
"10) Muista: käytä aina vaiheessa 1 laskettua profiilien järjestystä, kun valitset ja kirjoitat kuvaukset.\n" +
"FRAASISANASTO:\n" +
"D – Dominanssi: erittäin vahvasti: tekee päätöksiä nopeasti ja johdonmukaisesti, ottaa vastuun haastavissa tilanteissa, vie hankkeet määrätietoisesti maaliin; selkeästi: toimii määrätietoisesti ja tavoitteellisesti, käynnistää projekteja ja vie niitä eteenpäin; kohtalaisesti: ottaa johdon silloin kun tilanne vaatii, mutta tasapainottaa sen tiimin kanssa; heikosti: suosii selkeitä ohjeita ja toimii mieluummin osana tiimiä kuin sen johtajana.\n" +
"I – Vaikuttaminen: erittäin vahvasti: innostaa ympärillä olevia, rakentaa nopeasti luottamusta ja laajoja verkostoja; selkeästi: tuo positiivista energiaa ja kannustaa muita, edistää avointa vuorovaikutusta; kohtalaisesti: ylläpitää ystävällistä ilmapiiriä, osallistuu sosiaalisiin tilanteisiin valikoiden; heikosti: pitää vuorovaikutuksen asiallisena ja keskittyy ensisijaisesti tehtäviin.\n" +
"S – Vakaa tyyli: erittäin vahvasti: luo rauhallisen ja tasapainoisen ilmapiirin, on johdonmukainen ja tukeva tiimikaveri; selkeästi: on luotettava ja tasainen, arvostaa vakautta ja ennakoitavuutta; kohtalaisesti: toimii tasapainoisesti, mutta sopeutuu myös muuttuviin tilanteisiin; heikosti: viihtyy paremmin dynaamisessa ja vaihtelevassa työympäristössä.\n" +
"C – Tunnollisuus: erittäin vahvasti: työskentelee huolellisesti ja järjestelmällisesti, varmistaa korkean laadun ja ohjeiden noudattamisen; selkeästi: toimii järjestelmällisesti ja tarkasti, kiinnittää huomiota yksityiskohtiin; kohtalaisesti: arvostaa selkeitä rakenteita, mutta joustaa tarvittaessa; heikosti: ei seuraa tiukasti sääntöjä, mutta hyödyntää niitä tarvittaessa työn tukena.\n" +
"TUOTOS: Kirjoita kuvaus järjestyksessä vahvin → heikoin profiili käyttäen yllä olevia fraaseja voimakkuustason mukaan. Kuvaa ehdokasta konkreettisilla esimerkeillä toiminnasta työssä ja tiimissä. Päätä myönteisellä yhteenvedolla ehdokkaan yleisestä työskentelytavasta ja parhaasta työympäristöstä.";

        Debug.Log($"D = {results[0]}, I = {results[1]}, S = {results[2]}, C = {results[3]}. ");
        /*string prompt =
            $@"D = {results[0]}, I = {results[1]}, S = {results[2]}, C = {results[3]}.
            Olet henkilöstöpäällikkö, jolla on psykologinen koulutus. 
            Tehtäväsi on laatia ammatillinen ja myönteinen henkilöstökuvaus ehdokkaasta DISC-mallin perusteella.

            TOIMINTAOHJE:
            1) Järjestä profiilit D, I, S, C pistemäärien perusteella vahvimmasta heikoimpaan.
            2) Määritä kullekin profiilille voimakkuustaso pistehaarukan mukaan:
               105–125 = erittäin vahvasti kehittynyt
               85–104  = selkeästi kehittynyt
               65–84   = kohtalaisesti kehittynyt
               25–64   = heikosti kehittynyt
            3) Käytä alla olevaa FRAASISANASTOA valitun profiilin ja voimakkuustason mukaan. 
               Muokkaa lauseet luontevaksi kuvaukseksi ehdokkaasta (kolmannessa persoonassa).
            4) Ensimmäinen (vahvin) profiili saa pisimmän ja yksityiskohtaisimman kuvauksen, seuraavat lyhyemmät.
            5) Päätä tekstin myönteisellä yhteenvedolla: millaisessa ympäristössä ehdokas toimii parhaiten ja mitä hyötyä hän tuo tiimille.
            6) Älä mainitse pisteitä tai laskentaa.
            7) Pituus: 650–900 merkkiä, yhtenäinen kappale.

            FRAASISANASTO:

            D – Dominanssi
            - erittäin vahvasti: tekee päätöksiä nopeasti ja johdonmukaisesti, ottaa vastuun haastavissa tilanteissa, vie hankkeet määrätietoisesti maaliin
            - selkeästi: toimii määrätietoisesti ja tavoitteellisesti, käynnistää projekteja ja vie niitä eteenpäin
            - kohtalaisesti: ottaa johdon silloin kun tilanne vaatii, mutta tasapainottaa sen tiimin kanssa
            - heikosti: suosii selkeitä ohjeita ja toimii mieluummin osana tiimiä kuin sen johtajana

            I – Vaikuttaminen
            - erittäin vahvasti: innostaa ympärillä olevia, rakentaa nopeasti luottamusta ja laajoja verkostoja
            - selkeästi: tuo positiivista energiaa ja kannustaa muita, edistää avointa vuorovaikutusta
            - kohtalaisesti: ylläpitää ystävällistä ilmapiiriä, osallistuu sosiaalisiin tilanteisiin valikoiden
            - heikosti: pitää vuorovaikutuksen asiallisena ja keskittyy ensisijaisesti tehtäviin

            S – Vakaa tyyli
            - erittäin vahvasti: luo rauhallisen ja tasapainoisen ilmapiirin, on johdonmukainen ja tukeva tiimikaveri
            - selkeästi: on luotettava ja tasainen, arvostaa vakautta ja ennakoitavuutta
            - kohtalaisesti: toimii tasapainoisesti, mutta sopeutuu myös muuttuviin tilanteisiin
            - heikosti: viihtyy paremmin dynaamisessa ja vaihtelevassa työympäristössä

            C – Tunnollisuus
            - erittäin vahvasti: työskentelee huolellisesti ja järjestelmällisesti, varmistaa korkean laadun ja ohjeiden noudattamisen
            - selkeästi: toimii järjestelmällisesti ja tarkasti, kiinnittää huomiota yksityiskohtiin
            - kohtalaisesti: arvostaa selkeitä rakenteita, mutta joustaa tarvittaessa
            - heikosti: ei seuraa tiukasti sääntöjä, mutta hyödyntää niitä tarvittaessa työn tukena

            TUOTOS:
            Kirjoita kuvaus järjestyksessä vahvin → heikoin profiili käyttäen yllä olevia fraaseja voimakkuustason mukaan.
            Kuvaa ehdokasta konkreettisilla esimerkeillä toiminnasta työssä ja tiimissä. 
            Päätä myönteisellä yhteenvedolla ehdokkaan yleisestä työskentelytavasta ja parhaasta työympäristöstä.";*/

        //string prompt = $"D = {results[0]}, I = {results[1]}, S = {results[2]}, C = {results[3]}. Sinä olet henkilöstöpäällikkö, jolla on psykologinen koulutus. Arvioit ehdokasta DISC-mallin mukaisesti hänen vastattuaan 100 kysymykseen (25 kysymystä neljässä lohkossa: D, I, S ja C). Jokaisen lohkon pistemäärä vaihtelee välillä 25–125. Analysoi hänen tyyliään aloittaen aina vahvimmasta tyypistä (D, I, S, tai C) ja etene seuraaviin vahvuusjärjestyksessä. Älä mainitse pistemääriä. Kirjoita rakentava ja ammatillinen kuvaus, joka sopii sekä ehdokkaalle että esihenkilölle. Luo selkeä kokonaiskuva ehdokkaasta työntekijänä: kuinka hän toimii, mitä tuo tiimiin ja millaisessa ympäristössä toimii parhaiten. Käytä kunnioittavaa ja myönteistä sävyä. Pituus enintään 550 merkkiä."; 
        string response = await ChatGPTService.SendChatGPTRequest(prompt);

        GPTDescriptionText.text = response;
        ConfirmButton.interactable = true;

        candidate.ResultLetter = types[maxIndex];
        candidate.ResultGPT = response;
    }    

    public void Confirm()
    {
        CandidatesManager.SaveCandidate(CandidateController.Candidate);
        SceneManager.LoadScene(0);
    }
}
