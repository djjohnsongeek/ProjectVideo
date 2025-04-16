class ComplexCollectionInput {
    count = 1;
    propertyNames = [];
    labels = [];
    objectName = "";
    collectionContainer = null;

    constructor(containerId, objectName, propertyNames, labels) {
        if (labels.length != propertyNames.length) {
            throw new Error("The Properties and Label arrays have different lengths.");
        }

        this.collectionContainer = document.getElementById(containerId);
        this.propertyNames = propertyNames;
        this.objectName = objectName;
        this.labels = labels;
    }

    updateCount(n) {
        this.count += n;
        this.renderInputs();
    }

    renderInputs() {
        const rows = [];
        for (let i = 0; i < this.count; i++)
        {
            const containerRow = document.createElement("div");
            containerRow.className = "row";

            for (let j = 0; j < this.labels.length; j++) {
                const containerCol = document.createElement("div");
                containerCol.className = "col-6";

                const label = document.createElement("label");
                label.className = "form-label";
                const labelText = document.createTextNode(this.labels[j]);
                label.appendChild(labelText);

                const input = document.createElement("input");
                input.className = "form-control";
                input.name = `${this.objectName}[${i}].${this.propertyNames[j]}`;

                containerCol.appendChild(label);
                containerCol.appendChild(input);
                containerRow.appendChild(containerCol);
            }

            rows.push(containerRow);
        }

        this.collectionContainer.replaceChildren(...rows);
    }
}