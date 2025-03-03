document.addEventListener("DOMContentLoaded", function () {
    const form = document.getElementById("orderForm");
    const inputs = document.querySelectorAll(".input-style");


    function validateInput(input) {
        if (!input.checkValidity()) {
            input.classList.add("is-invalid");
            return false;
        } else {
            input.classList.remove("is-invalid");
            return true;
        }
    }


    inputs.forEach(input => {
        input.addEventListener("input", function () {
            validateInput(input);
        });
    });

    form.addEventListener("submit", function (event) {
        let valid = true;

        inputs.forEach(input => {
            if (!validateInput(input)) {
                valid = false;
            }
        });

        if (!valid) {
            event.preventDefault();
        }
    });


    const productElements = document.querySelectorAll(".produit-clickable");

    productElements.forEach(product => {
        product.addEventListener("click", function () {

            document.querySelectorAll(".product-bubble").forEach(bubble => {
                bubble.classList.remove("active-bubble");
            });

            if (this.classList.contains("product-bubble")) {
                this.classList.add("active-bubble");
            }


            const productId = this.getAttribute("data-id");
            const productName = this.getAttribute("data-nom");
            const productDescription = this.getAttribute("data-description");
            const productPrice = this.getAttribute("data-prix");
            const productImage = this.getAttribute("data-image");


            document.getElementById("productImage").src = productImage;
            document.getElementById("productName").textContent = productName;
            document.getElementById("productDescription").textContent = productDescription;
            document.getElementById("productPrice").textContent = productPrice;
            document.getElementById("selectedProductId").value = productId;


            window.scrollTo({ top: 0, behavior: 'smooth' });
        });
    });
});