/* Scroll Reveal Animation */

const sr = ScrollReveal({
  origin: "top",
  distance: "60px",
  duration: 2500,
  delay: 400,
});

sr.reveal(".landing .text, footer", { delay: 500 });
sr.reveal(".landing .buttons", { delay: 500 });
sr.reveal(".landing img", { delay: 500 });
sr.reveal(".earn-coin", { delay: 700, origin: "bottom" });
sr.reveal(".about img", { interval: 100 });
sr.reveal(".support-questions .text-information", {
  delay: 800,
  origin: "left",
});
sr.reveal(".about .text-information, .support-questions img", {
  delay: 800,
  origin: "right",
});
