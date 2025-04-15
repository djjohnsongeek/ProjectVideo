class CollectionInput {
    count = 1;
    fieldNames = [];
    baseName = "";
    container = null;

    constructor(containerId, baseName, fieldNames) {
        this.container = document.getElementById(containerId);
        this.fieldNames = fieldNames;
        this.baseName = baseName;
    }

    renderInputs() {
        for (let i = 0; i < this.count; i++)
        {

        }
    }
}