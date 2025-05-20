$(document).ready(function () {
    const recipeListKey = "publishedRecipes";

    // 1. Inicializa datos predeterminados si localStorage está vacío
    function initializeDefaultRecipes() {
        const defaultRecipes = [
            {
                title: "Receta 1",
                description: "Descripción de la receta 1.",
                image: "/path/to/default-image.jpg",
                rating: "★★★★★"
            },
            {
                title: "Receta 2",
                description: "Descripción de la receta 2.",
                image: "/path/to/default-image.jpg",
                rating: "★★★★☆"
            },
            {
                title: "Receta 3",
                description: "Descripción de la receta 3.",
                image: "/path/to/default-image.jpg",
                rating: "★★★☆☆"
            }
        ];
        localStorage.setItem(recipeListKey, JSON.stringify(defaultRecipes));
    }

    // 2. Cargar recetas almacenadas en localStorage
    function loadRecipes() {
        let recipes = JSON.parse(localStorage.getItem(recipeListKey));
        if (!recipes || recipes.length === 0) {
            initializeDefaultRecipes(); // Inicializa recetas si está vacío
            recipes = JSON.parse(localStorage.getItem(recipeListKey)); // Recarga después de inicializar
        }
        $("#recipe-list").empty(); // Limpia la lista antes de regenerarla
        recipes.forEach((recipe, index) => {
            const recipeHTML = `
                <div class="recipe-item" data-index="${index}">
                    <div class="recipe-image">
                        <img src="${recipe.image}" alt="Imagen de la receta">
                    </div>
                    <div class="recipe-details">
                        <h2 class="recipe-title">
                            <a href="/Cuenta/DetalleReceta/${index}" class="recipe-link">${recipe.title}</a>
                        </h2>
                        <p>${recipe.description}</p>
                        <div class="rating">${recipe.rating}</div>
                    </div>
                    <div class="actions">
                        <button class="btn-edit" data-index="${index}">✎</button>
                        <button class="btn-delete" data-index="${index}">🗑</button>
                    </div>
                </div>
            `;
            $("#recipe-list").append(recipeHTML);
        });
    }

    // 3. Guardar recetas en localStorage
    function saveRecipes(recipes) {
        localStorage.setItem(recipeListKey, JSON.stringify(recipes));
    }

    // 5. Editar una receta
    $(document).on("click", ".btn-edit", function () {
        const index = $(this).data("index");
        window.location.href = `https://localhost:7205/Cuenta/EditarCrear?id=${index}`;
    });

    // 6. Eliminar una receta
    $(document).on("click", ".btn-delete", function () {
        const index = $(this).data("index");
        const recipes = JSON.parse(localStorage.getItem(recipeListKey)) || [];
        if (confirm("¿Estás seguro de que deseas eliminar esta receta?")) {
            recipes.splice(index, 1); // Elimina la receta del array
            saveRecipes(recipes);
            loadRecipes();
        }
    });

    // Inicializa la lista de recetas
    loadRecipes();
});