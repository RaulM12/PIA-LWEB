$(document).ready(function () {
    // 1. Actualizar nombre
    $(".edit-name").click(function () {
        $("#editNameModal").modal("show");
    });

    $("#saveNameButton").off("click").on("click", function () {
        const newName = $("#newNameInput").val().trim();
        if (newName) {
            $("#name-text").text(newName); // Actualiza el nombre en la página
            $("#editNameModal").modal("hide"); // Cierra el modal
            // Mostrar un mensaje de éxito en la página
            $(".success-message").remove(); // Limpia mensajes previos
            $("<div class='success-message text-success mt-2'>Nombre actualizado exitosamente.</div>")
                .insertAfter(".profile-info");
        } else {
            // Mostrar un mensaje de error en el modal
            $(".modal-body .error-message").remove(); // Limpia mensajes previos
            $("<div class='error-message text-danger mt-2'>Por favor, introduce un nombre válido.</div>")
                .appendTo(".modal-body");
        }
    });

    // 2. Cambiar la foto de perfil
    $(".edit-photo").click(function () {
        $("#upload-photo").trigger("click"); // Simula un clic en el input oculto
    });

    $("#upload-photo").change(function () {
        const file = this.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = function (e) {
                $("#profile-picture img").attr("src", e.target.result); // Actualiza la foto
                $(".success-message").remove(); // Limpia mensajes previos
                $("<div class='success-message text-success mt-2'>Foto de perfil actualizada exitosamente.</div>")
                    .insertAfter(".profile-info");
            };
            reader.readAsDataURL(file); // Convierte la imagen seleccionada a Base64
        }
    });

    // 3. Filtrar recetas favoritas
    let activeFilter = null; // Variable para rastrear el filtro activo

    $(".filter-buttons .btn").click(function () {
        const filter = $(this).data("filter");

        if (activeFilter === filter) {
            // Si el filtro ya está activo, reiniciamos la vista
            $(".recipe-card").fadeIn(); // Muestra todas las recetas
            $(".filter-buttons .btn").removeClass("active"); // Quita la clase activa de todos los botones
            activeFilter = null; // Reseteamos el filtro activo
        } else {
            // Aplicar el filtro
            activeFilter = filter; // Actualiza el filtro activo
            $(".recipe-card").hide(); // Oculta todas las recetas
            $(`.recipe-card[data-category="${filter}"]`).fadeIn(); // Muestra las recetas filtradas

            // Actualiza la clase activa del botón
            $(".filter-buttons .btn").removeClass("active"); // Quita la clase activa de otros botones
            $(this).addClass("active"); // Agrega la clase activa al botón seleccionado
        }
    });

    // 4. Redirigir a recetas publicadas
    $(".btn-published").click(function () {
        window.location.href = "/Cuenta/RecetasPublicadas";
    });
});