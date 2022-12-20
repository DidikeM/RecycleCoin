/* Scroll Reveal Animation */

const sr = ScrollReveal({
    origin: "top",
    distance: "60px",
    duration: 2500,
    delay: 400,
});

sr.reveal(".landing .text, footer", { delay: 500 });
sr.reveal(".landing .buttons", { delay: 500 });
sr.reveal(".landing img, .bitcoin-api", { delay: 500 });
sr.reveal(".earn-coin", { delay: 700, origin: "bottom" });
/*sr.reveal(".about img", { interval: 100 });*/
sr.reveal(".support-questions .text-information,.about img", {
    delay: 800,
    origin: "left",
});
sr.reveal(".about .text-information, .support-questions img", {
    delay: 800,
    origin: "right",
});

var btc = document.getElementById("bitcoin");
var ltc = document.getElementById("litecoin");
var eth = document.getElementById("ethereum");
var doge = document.getElementById("dogecoin");
var usdt = document.getElementById("tether");
var xrp = document.getElementById("ripple");
var sol = document.getElementById("solana");
var trx = document.getElementById("tron");
var ada = document.getElementById("cardano");

var options = {
    method: "GET",
    headers: {},
};

fetch(
    "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin%2Clitecoin%2Cethereum%2Cdogecoin%2Ctether%2Csolana%2Cripple%2Ctron%2Ccardano&vs_currencies=usd",
    options
)
    .then((response) => response.json())
    .then(
        (response) => (
            (btc.innerHTML = response.bitcoin.usd),
            (ltc.innerHTML = response.litecoin.usd),
            (eth.innerHTML = response.ethereum.usd),
            (doge.innerHTML = response.dogecoin.usd),
            (usdt.innerHTML = response.tether.usd),
            (xrp.innerHTML = response.ripple.usd),
            (sol.innerHTML = response.solana.usd),
            (trx.innerHTML = response.tron.usd),
            (ada.innerHTML = response.cardano.usd),
            (ltc.innerHTML = response.litecoin.usd)
        )
    )
    .catch((err) => console.error(err));
