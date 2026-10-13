// Space Week Day 7: Launch Fuel
// For the final day of Space Week, you will be given the mass in kilograms (kg) of a payload you want to send to orbit. Determine the amount of fuel needed to send your payload to orbit using the following rules:

// Rockets require 1 kg of fuel per 5 kg of mass they must lift.
// Fuel itself has mass. So when you add fuel, the mass to lift goes up, which requires more fuel, which increases the mass, and so on.
// To calculate the total fuel needed: start with the payload mass, calculate the fuel needed for that, add that fuel to the total mass, and calculate again. Repeat this process until the additional fuel required is less than 1 kg, then stop.
// Ignore the mass of the rocket itself. Only compute fuel needed to lift the payload and its own fuel.
// For example, given a payload mass of 50 kg, you would need 10 kg of fuel to lift it (payload / 5), which increases the total mass to 60 kg, which needs 12 kg to lift (2 additional kg), which increases the total mass to 62 kg, which needs 12.4 kg to lift - 0.4 additional kg - which is less 1 additional kg, so we stop here. The total mass to lift is 62.4 kg, 50 of which is the initial payload and 12.4 of fuel.

// Return the amount of fuel needed rounded to one decimal place.


// function launchFuel(payload) {
//   let totalMass = payload;
//   let totalFuel = 0;
//   let previousFuel = 0;

//   while (true) {
//     const requiredFuel = totalMass / 5;
//     const additionalFuel = requiredFuel - previousFuel;

//     if (additionalFuel < 1) {
//       return Math.round(requiredFuel * 10) / 10;
//     }

//     totalFuel = requiredFuel;
//     totalMass = payload + totalFuel;
//     previousFuel = totalFuel;
//   }
// }

// console.log(launchFuel(50));


// https://www.freecodecamp.org/learn/daily-coding-challenge/10-10



// 12-10-206

// https://www.freecodecamp.org/learn/daily-coding-challenge/10-11

// function hexToDecimal(hex){
//   return parseInt(hex, 16);
// }




// function battle(ourTeam, oppenent){

//   const lower = {
//   "A": 1,
//   "B": 2,
//   "C": 3,
//   "D": 4,
//   "E": 5,
//   "F": 6,
//   "G": 7,
//   "H": 8,
//   "I": 9,
//   "J": 10,
//   "K": 11,
//   "L": 12,
//   "M": 13,
//   "N": 14,
//   "O": 15,
//   "P": 16,
//   "Q": 17,
//   "R": 18,
//   "S": 19,
//   "T": 20,
//   "U": 21,
//   "V": 22,
//   "W": 23,
//   "X": 24,
//   "Y": 25,
//   "Z": 26
// }

// const cap = {
//   "A": 2,
//   "B": 4,
//   "C": 6,
//   "D": 8,
//   "E": 10,
//   "F": 12,
//   "G": 14,
//   "H": 16,
//   "I": 18,
//   "J": 20,
//   "K": 22,
//   "L": 24,
//   "M": 26,
//   "N": 28,
//   "O": 30,
//   "P": 32,
//   "Q": 34,
//   "R": 36,
//   "S": 38,
//   "T": 40,
//   "U": 42,
//   "V": 44,
//   "W": 46,
//   "X": 48,
//   "Y": 50,
//   "Z": 52
// }

// function calculate(arr){

//   let res = 0;
//   for(const word of arr){
//     for(let i=0; i<word.length; i++){
//       let ch = word[i];
//       if(ch === ch.toLowerCase()){
//         res = res + lower[ch];
//       }else{

//         res = res+cap[ch];
//       }
//     }
//   }
//   return res;
// }


//   const ourWords = ourTeam.split(" ");
//   const oppenentWords = oppenent.split(" ");

//   const oppRes = calculate(oppenentWords);
//   const res = calculate(ourWords);
  

//   if(oppRes > res){
//     return "We Loss";
//   }else if(res>oppRes){
//     return "We Win";
//   }else{
//     return "Draw";
//   }



// }

// console.log(battle("Cheeseburger with fries", "Cheeseburger with Fries"));




// https://www.freecodecamp.org/learn/daily-coding-challenge/10-13



function to12(time) {
    console.log(typeof time);
  const hours = Number(time.slice(0, 2));
  console.log("hour", hours);
  const minutes = time.slice(2);
  console.log("M", minutes);

  const period = hours < 12 ? "AM" : "PM";

  let convertedHours;

  if (hours === 0) {
    convertedHours = 12;
  } else if (hours > 12) {
    convertedHours = hours - 12;
  } else {
    convertedHours = hours;
  }

  return `${convertedHours}:${minutes} ${period}`;
}

console.log(to12("1124")); // "11:24 AM"
console.log(to12("0900")); // "9:00 AM"
console.log(to12("1455")); // "2:55 PM"
console.log(to12("0000")); // "12:00 AM"
console.log(to12("1200")); // "12:00 PM"
