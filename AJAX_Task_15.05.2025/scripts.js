document.getElementById("predictBtn").addEventListener("click", predictAge);

document.getElementById("nameInput").addEventListener("keypress", function (event) {
  if (event.key === "Enter") {
    predictAge();
  }
});

function predictAge() {
  const name = document.getElementById("nameInput").value.trim();
  const container = document.getElementById("resultContainer");

  container.innerHTML = "";

  if (!name) {
    container.innerHTML = `<p class="text-danger">Please enter a valid name.</p>`;
    return;
  }

  fetch(`https://api.agify.io?name=${encodeURIComponent(name)}`)
    .then(response => {
      if (!response.ok) {
        throw new Error("Network response was not OK");
      }
      return response.json();
    })
    .then(data => {
      if (!data.age) {
        container.innerHTML = `<p class="text-warning">Could not predict age for 
        "<strong>${data.name}</strong>". Try another name.</p>`;
        return;
      }

      container.innerHTML = `
        <div class="card mx-auto shadow-sm" style="max-width: 400px;">
          <div class="card-body">
            <h5 class="card-title">Name: ${data.name}</h5>
            <p class="card-text">Predicted Age: <strong>${data.age}</strong></p>
            <p class="card-text">Based on <strong>${data.count}</strong> people</p>
          </div>
        </div>
      `;
    })
    .catch(error => {
      console.error("Error fetching data:", error);
      container.innerHTML = `<p class="text-danger">Something went wrong.
       Please try again later.</p>`;
    });
}
