//make feedback invisible by default and attach click listeners to display and feedback
const feedbackContainer = document.getElementById("feedbackContainer");
const feedbackDisplay = document.getElementById("displayFeedback");
feedbackDisplay.style.display = "none";
const descriptionContainer = document.getElementById("descriptionContainer");
feedbackContainer.addEventListener('click', makeFeedbackActive);
descriptionContainer.addEventListener('click', makeDescriptionActive);

// set initial value of description in edit project form
const descriptionP = document.getElementById("projectDescriptionP");
const descriptionTextArea = document.getElementById("Description");
descriptionTextArea.textContent = descriptionP.innerText;

//makes feedback active and hides description
function makeFeedbackActive()
{
    const feedbackDisplay = document.getElementById("displayFeedback");
    feedbackDisplay.style.display = "block";
    const feedbackContainer = document.getElementById("feedbackContainer");
    feedbackContainer.classList.toggle("active-container");
    const descriptionDisplay = document.getElementById("displayDescription");
    descriptionDisplay.style.display = "none";
    const descriptionContainer = document.getElementById("descriptionContainer");
    descriptionContainer.classList.toggle("active-container");
}

//makes description active and hides feedback
function makeDescriptionActive()
{
    const descriptionDisplay = document.getElementById("displayDescription");
    descriptionDisplay.style.display = "block";
    const descriptionContainer = document.getElementById("descriptionContainer");
    descriptionContainer.classList.toggle("active-container");
    const feedbackDisplay = document.getElementById("displayFeedback");
    feedbackDisplay.style.display = "none";
    const feedbackContainer = document.getElementById("feedbackContainer");
    feedbackContainer.classList.toggle("active-container");
}



