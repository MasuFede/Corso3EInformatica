let titleRecipes = document.getElementById("titleRecipes");
let Rating = document.getElementById("Rating");
let tag1 = document.getElementById("tag1");
let tag2 = document.getElementById("tag2");
let igredientsList = document.getElementById("igredientsList");
let infoList = document.getElementById("infoList");
let istructionsList = document.getElementById("istrutcionsList");

let spazio = document.createElement("br");

async function GetData() {
  try {
    const response = await fetch("https://dummyjson.com/recipes/1");
    let data = await response.json();
    console.log(data);

    titleRecipes.append(data.name);
    Rating.append(data.rating);
    tag1.append(data.tags[0]);
    tag2.append(data.tags[1]);
    data.ingredients.forEach((element) => {
      let liIngredients = document.createElement("li");
      liIngredients.textContent = element;
      igredientsList.append(liIngredients);
    });
    // data.instructions.forEach((element) => {
    //   let liInfo = document.createElement("li");
    //   liInfo.textContent = element;
    //   infoList.append(liInfo);
    // });
    data.instructions.forEach((element) => {
      let liInstructions = document.createElement("li");
      liInstructions.textContent = element;
      istructionsList.append(liInstructions);
    });
  } catch (error) {
    console.error("erorr", error);
  }
}
GetData();
