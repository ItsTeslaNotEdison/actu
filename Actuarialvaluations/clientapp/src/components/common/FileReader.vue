<template>
 <div id="fileUploadID" class="mb-2 custom-file b-form-file">
   <input type="file" id="fileUploadID" accept=".csv" class="custom-file-input" @change="loadTextFromFile"  >
   <label for="fileUploadID" class="custom-file-label">{{ this.filename }}</label>
 </div>
</template>

<script>
export default {
data() {
      return {
        filename: 'Choose a file...'     
      }
    },
  methods: {
    loadTextFromFile(ev) {
      const file = ev.target.files[0];
      this.filename = file.name;
      console.log(file);
      const reader = new FileReader();
      reader.onload = e => this.$emit("load", e.target.result);
      reader.readAsText(file);
    }
  }
};
</script>

<style>
.text-reader {
  position: relative;
  overflow: hidden;
  display: inline-block;

  /* Fancy button looking */
  border: 2px solid black;
  border-radius: 5px;
  padding: 8px 12px;
  cursor: pointer;
}
.text-reader input {
  position: absolute;
  top: 0;
  left: 0;
  z-index: -1;
  opacity: 0;
}
</style>
