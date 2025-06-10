class ComplexInputCollection {
    collectionContainer;
    inputGroups;
    constructor(containerId) {
        this.collectionContainer = document.getElementById(containerId);
        this.inputGroups = [];
    }
    addInputGroup(inputGroup) {
        this.inputGroups.push(inputGroup);
        this.renderInputs();
    }
    handleInputValueChanges(event) {
        const input = event.currentTarget;
        const guidId = input.id;
        this.setInputValue(input.value, guidId);
    }
    handleInputRemoveBtn(event) {
        const input = event.currentTarget;
        const guidId = input.dataset.deleteTarget;
        this.inputGroups = this.inputGroups.filter((item) => {
            return item.guidId != guidId;
        });
        this.renderInputs();
    }
    setInputValue(value, guidId) {
        let complexInput = this.getInputById(guidId);
        if (complexInput !== null) {
            complexInput.inputValue = value;
        }
        else {
            console.error("Failed to set input value. No input data found.");
        }
    }
    getInputById(guidId) {
        for (let inputGroup of this.inputGroups) {
            for (let complexInput of inputGroup.inputs) {
                if (complexInput.elementId == guidId) {
                    return complexInput;
                }
            }
        }
        return null;
    }
    renderInputs() {
        const rows = [];
        for (let i = 0; i < this.inputGroups.length; i++) {
            const containerRow = document.createElement("div");
            containerRow.className = "row mb-3 pt-1 pb-4 border-bottom border-2";
            for (let j = 0; j < this.inputGroups[i].inputs.length; j++) {
                const containerCol = document.createElement("div");
                containerCol.className = "col-md-5";
                const label = document.createElement("label");
                label.className = "form-label";
                const labelText = document.createTextNode(this.inputGroups[i].inputs[j].labelName);
                label.appendChild(labelText);
                const input = document.createElement("input");
                input.className = "form-control";
                input.name = `${this.inputGroups[i].objectName}[${i}].${this.inputGroups[i].inputs[j].propertyName}`;
                input.id = this.inputGroups[i].inputs[j].elementId;
                input.value = this.inputGroups[i].inputs[j].inputValue;
                if (this.inputGroups[i].inputs[j].inputDatalistId !== null) {
                    input.setAttribute("list", this.inputGroups[i].inputs[j].inputDatalistId);
                }
                input.addEventListener("change", (event) => this.handleInputValueChanges(event));
                containerCol.appendChild(label);
                containerCol.appendChild(input);
                containerRow.appendChild(containerCol);
            }
            const deleteCol = document.createElement("div");
            deleteCol.className = "col-md-2";
            const deleteInput = document.createElement("input");
            deleteInput.className = "btn btn-outline-danger form-control";
            deleteInput.type = "button";
            deleteInput.value = "Remove";
            deleteInput.dataset.deleteTarget = this.inputGroups[i].guidId;
            deleteInput.addEventListener("click", (event) => this.handleInputRemoveBtn(event));
            const deleteBtnLabel = document.createElement("label");
            deleteBtnLabel.appendChild(document.createTextNode("Remove Url"));
            deleteBtnLabel.className = "form-label";
            deleteBtnLabel.style.visibility = "hidden";
            deleteCol.appendChild(deleteBtnLabel);
            deleteCol.appendChild(deleteInput);
            containerRow.appendChild(deleteCol);
            rows.push(containerRow);
        }
        this.collectionContainer.replaceChildren(...rows);
    }
}

class ComplexInput {
    constructor(labelName, propertyName, elementId, inputValue, inputDatalistId = null) {
        this.labelName = labelName;
        this.propertyName = propertyName;
        this.elementId = elementId;
        this.inputValue = inputValue;
        this.inputDatalistId = inputDatalistId;
    }
}

class ComplexObjectInputGroup {
    constructor(objectName, guidId) {
        this.objectName = objectName;
        this.guidId = guidId;
        this.inputs = [];
    }

    addInput(complexInput) {
        this.inputs.push(complexInput);
    }
}