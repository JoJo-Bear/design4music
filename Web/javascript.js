window.addEventListener('load', init);

var userID;
var kleur;
var tiltTekst;
var refresh = false;


window.onbeforeunload = function (event) {
    var id = userID;
    var k = kleur;
    refresh = true;

    userID = "";
    kleur = "";


    firebase.database().ref('users/' + k).child(id).remove();


};


function init() {

    // Set the configuration for your app
    // TODO: Replace with your project's config object
    // Initialize Firebase
    var config = {
        apiKey: "AIzaSyCLEq3xptPCEZ7h6rNq8ym7Fmw7NtpAGt0",
        authDomain: "design4music-b0ca8.firebaseapp.com",
        databaseURL: "https://design4music-b0ca8.firebaseio.com",
        projectId: "design4music-b0ca8",
        storageBucket: "",
        messagingSenderId: "439866012298"
    };
    firebase.initializeApp(config);

    // Get a reference to the database service
    var database = firebase.database();


// verkrijgt userID via getNumber
    getNumber();
    kleur = chooseTeam();

    document.body.style.background = "#" + kleur;

    tiltText = document.getElementById("tilt");
    // var tilt;
    //
    // tiltText.innerHTML = "Hallo hier komt de data te staan";
    // console.log(event.acceleration);
    // console.log(event.accelerationIncludingGravity);
    // console.log(event);
    //
    // tiltText.innerHTML = JSON.stringify(event);


    // }


}


function chooseTeam() {

    // var team = ["red", "blue", "yellow", "green"];
    var team = ["ff2640", "00ffff"];

    return team[Math.floor(Math.random() * team.length)];

}


function koppelGebruiker(id, kleur) {
    firebase.database().ref('users/' + kleur + "/" + id).set({
        Waarden: 0
    });
}


function getNumber() {

    firebase.database().ref('nummer/').once('value').then(function (snapshot) {
        var nummer = snapshot.val()
        userID = nummer + 1;
        updateNumber(nummer);

        startDeelname();
    });

}


function updateNumber(nummer) {

    nummer = nummer + 1;

    // Write the new post's data simultaneously in the posts list and the user's post list.
    var updates = {};
    updates['nummer/'] = nummer;

    return firebase.database().ref().update(updates);
}


function updateGebruiker(userID, kleur, waarden) {
    // A post entry.
    var postData = {
        Waarden: waarden
    };

    // Write the new post's data simultaneously in the posts list and the user's post list.
    var updates = {};
    updates['users/' + kleur + "/" + userID] = postData;

    return firebase.database().ref().update(updates);
}


function startDeelname() {

    koppelGebruiker(userID, kleur);

    window.addEventListener('devicemotion', function () {
        event.accelerationIncludingGravity.x
        event.accelerationIncludingGravity.y
        event.accelerationIncludingGravity.z

        tilt = event.accelerationIncludingGravity.x;

        if (refresh != true) {

            // samsung gear is veel onprecies registreet veel minder verschil
            //if (event.accelerationIncludingGravity.y <= -6 || event.accelerationIncludingGravity.y >= 6) {
              if (event.accelerationIncludingGravity.x <= -20 || event.accelerationIncludingGravity.x >= 20) {

                updateGebruiker(userID, kleur, 1);
            }
            else {
                updateGebruiker(userID, kleur, 0);
            }
            // tiltText.innerHTML = event.accelerationIncludingGravity.x + " " + event.accelerationIncludingGravity.y + " " + event.accelerationIncludingGravity.z;
        }


    })


}