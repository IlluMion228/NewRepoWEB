document.addEventListener("input", function (event) {
    if (event.target.classList.contains("auto-expand")) {
        event.target.style.height = "auto";
        event.target.style.height = event.target.scrollHeight + "px";
    }
});

document.addEventListener("DOMContentLoaded", function () {
    const phoneInput = document.getElementById("PhoneNumber");
    const template = "(___) ___-____";

    function formatPhone(value) {
        let formatted = "";
        let valueIndex = 0;

        for (let i = 0; i < template.length; i++) {
            if (template[i] === "_") {
                if (valueIndex < value.length) {
                    formatted += value[valueIndex];
                    valueIndex++;
                } else {
                    formatted += "_";
                }
            } else {
                formatted += template[i];
            }
        }
        return formatted;
    }

    phoneInput.addEventListener("mouseover", function () {
        if (!phoneInput.value) {
            phoneInput.placeholder = template;
        }
    });

    phoneInput.addEventListener("mouseout", function () {
        if (!phoneInput.value) {
            phoneInput.placeholder = "(000) 000-0000";
        }
    });

    phoneInput.addEventListener("focus", function () {
        if (!phoneInput.value) {
            phoneInput.value = template;
        }
    });

    phoneInput.addEventListener("blur", function () {
        if (phoneInput.value === template) {
            phoneInput.value = "";
        }
    });

    // Обработка Backspace
    phoneInput.addEventListener("keydown", function (event) {
        if (event.key === "Backspace") {
            event.preventDefault();
            let value = phoneInput.value.replace(/\D/g, "");

            if (value.length > 0) {
                value = value.slice(0, -1);
                phoneInput.value = formatPhone(value);

                const lastPosition = phoneInput.value.indexOf("_");
                phoneInput.setSelectionRange(lastPosition, lastPosition);
            }
        }
    });

    // Обработка ввода
    phoneInput.addEventListener("input", function () {
        const value = phoneInput.value.replace(/\D/g, "");
        phoneInput.value = formatPhone(value);

        const lastPosition = phoneInput.value.indexOf("_");
        if (lastPosition !== -1) {
            phoneInput.setSelectionRange(lastPosition, lastPosition);
        }
    });
});