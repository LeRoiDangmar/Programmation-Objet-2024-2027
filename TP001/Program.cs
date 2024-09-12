using System;
using System.ComponentModel.Design;

const string MESSAGE_BIENVENUE = "Bienvenu sur mon programme, jeune étranger très poilu";

string prenomUtilisateur = string.Empty;
string nomUtilisateur =  string.Empty;

int tailleUtilisateur = 0;
int ageUtilisateur = 0;
float poidsUtilisateur = 0;
float imcUtilisateur = 0;
int nbCheveuxUtilisateur = 0;

bool testNombreCheveux = false;
bool testNombrePoids = false;
bool testNombreAge = false;
bool testNombreTaille = false;
bool testStringPrenom = true;
bool testStringNom = true;

bool lancerProgramme = true;


void VerificationAge(int age){
    const string MESSAGE_MECHANT = "Ta propre mère ne te respecte pas et souhaiterait que tu disparaisses dans les abysses. En plus tu peux pas d'exploser la tête avec un max d'alcool.";

    if(ageUtilisateur >= 18){
        Console.WriteLine("TU EST LE GOAT");
    }else if(ageUtilisateur < 18) {
        Console.WriteLine(MESSAGE_MECHANT);
    }
}

string FormatageUtilisateur(string prenom, string nom){
    string nomFormate = prenomUtilisateur + " " + nomUtilisateur.ToUpper() + " !";
    return nomFormate;
}

float ImcUtilisateur(float poids, int taille){
    float imc = 0;

    float poidsFloat = ((float)poids);
    double tailleDoubleEnMetre = (double)taille/100;

    imc = (float)(poids/Math.Pow(tailleDoubleEnMetre,2));

    return imc;
}

void CommenterImc(float imc){
    const string MESSAGE_ANOREXIE = "Attention à l'anorexie : ";
    const string MESSAGE_MAIGRICHON = "Vous êtes un peu maigre : ";
    const string MESSAGE_CORPULENCE_NORMALE = "Vous êtes de corpulence normale : ";
    const string MESSAGE_SURPOIDS = "Vous êtes en surpoids : ";
    const string MESSAGE_OBESITE_MODEREE = "Obésité modérée : ";
    const string MESSAGE_OBESITE_SEVERE = "Obésité sévère : ";
    const string MESSAGE_OBESITE_MORBIDE = "Obésité morbide : ";

    if(imc < 16.5){
        Console.WriteLine(MESSAGE_ANOREXIE);
    }else if(imc < 18.5 && imc >= 16.5){
        Console.WriteLine(MESSAGE_MAIGRICHON);
    }else if(imc < 25 && imc >= 18.5){
        Console.WriteLine(MESSAGE_CORPULENCE_NORMALE);
    }else if(imc < 30 && imc >= 25){
        Console.WriteLine(MESSAGE_SURPOIDS);
    }else if (imc < 35 && imc >= 30){
        Console.WriteLine(MESSAGE_OBESITE_MODEREE);
    }else if (imc < 40 && imc >= 35){
        Console.WriteLine(MESSAGE_OBESITE_SEVERE);
    }else if (imc >= 40){
        Console.WriteLine(MESSAGE_OBESITE_MORBIDE);
    }

}


void Compter(int max){
    for(int i = 1; i <= 10; i++){
        Console.WriteLine(i);
    }
}

void TelephoneTata(){
    const string messageTata = "Bonjour, vous êtes bien sur le téléphonede tat jacqueline pour toute demande de tarification pour un max de drogue merci de me laisser un message";
    Console.WriteLine("Appel en cours...");
    Console.WriteLine(messageTata);
}

void Menu(){
    int choix = 0;
    bool testChiffre = false;
    Console.WriteLine("Choissisez une option");
    Console.WriteLine("1 - Quitter le Programme");
    Console.WriteLine("2 - Recommencer le Programme");
    Console.WriteLine("3 - Compter jusqu'à 10");
    Console.WriteLine("4 - Téléphoner à Tata Jacqueline");

    do{
        testChiffre = int.TryParse(Console.ReadLine(), out choix);
        if(testChiffre == false){
            Console.WriteLine("HEHO FAUT ENTRER UN NOMBRE. Recommence");
        }
        if(choix < 1 || choix > 5){
            Console.WriteLine("Alors, tu sais lire ou pas trop ? Recommence");
        }
    }while(testChiffre == false || choix < 1 || choix > 5);

    switch(choix)
    {
        case 1: 
            lancerProgramme = false;
            break;
        
        case 2:
            lancerProgramme = true;
            break;
        case 3:
            Compter(10);
            lancerProgramme = false;
            break;
            

        case 4:
            TelephoneTata();
            lancerProgramme = false;
            break;
            
    }

}

do{

    Console.WriteLine(MESSAGE_BIENVENUE);


    do{
        Console.WriteLine("Quel est ton prénom ?");
        prenomUtilisateur = Console.ReadLine();
        testStringPrenom = prenomUtilisateur.Any(char.IsDigit);

        if(testStringPrenom == true){
            Console.WriteLine("HEHO FAUT ENTRER UN STRING SANS CHIFFRES DEDANS. Recommence");
        }

    }while(testStringPrenom == true);



    do{
        Console.WriteLine("Quel est ton nom ?");
        nomUtilisateur = Console.ReadLine();
        testStringNom = nomUtilisateur.Any(char.IsDigit);

        if(testStringNom == true){
            Console.WriteLine("HEHO FAUT ENTRER UN STRING SANS CHIFFRES DEDANS. Recommence");
        }

    }while(testStringNom == true);


    Console.WriteLine("Bonjour " + FormatageUtilisateur(prenomUtilisateur, nomUtilisateur));


    do{
        Console.WriteLine("Quel est ta taille (en cm) ?");
        testNombreTaille = int.TryParse(Console.ReadLine(), out tailleUtilisateur);

        if(testNombreTaille == false){
            Console.WriteLine("HEHO FAUT ENTRER UN NOMBRE. Recommence");
        }

    }while(testNombreTaille == false);



    do{
        Console.WriteLine("Quel est ton age (en année)?");
        testNombreAge = int.TryParse(Console.ReadLine(), out ageUtilisateur);

        if(testNombreAge == false){
            Console.WriteLine("HEHO FAUT ENTRER UN NOMBRE. Recommence");
        }

    }while(testNombreAge == false);


    do{
        Console.WriteLine("Quel est ton poids (en kilo)?");
        testNombrePoids = float.TryParse(Console.ReadLine(), out poidsUtilisateur);

        if(testNombrePoids == false){
            Console.WriteLine("HEHO FAUT ENTRER UN NOMBRE. Recommence");
        }

    }while(testNombrePoids == false);


    VerificationAge(ageUtilisateur);

    imcUtilisateur = ImcUtilisateur(poidsUtilisateur, tailleUtilisateur);

    Console.WriteLine("Ton IMC est : " + imcUtilisateur.ToString("0.0"));

    CommenterImc(imcUtilisateur);

    do{
        Console.WriteLine("Entrez une estimation du nombre de cheveux que vous avez sur la tête");
        testNombreCheveux = int.TryParse(Console.ReadLine(), out nbCheveuxUtilisateur);

        if(testNombreCheveux == false){
            Console.WriteLine("HEHO FAUT ENTRER UN NOMBRE. Recommence");
        }

        if(nbCheveuxUtilisateur <100000 || nbCheveuxUtilisateur > 150000){
            Console.WriteLine("Regardez le tous comme il est bête (montrez le du doigt). Recommence");
        }

    }while(testNombreCheveux == false || nbCheveuxUtilisateur <100000 || nbCheveuxUtilisateur > 150000);


    Menu();

}while(lancerProgramme == true);

return;