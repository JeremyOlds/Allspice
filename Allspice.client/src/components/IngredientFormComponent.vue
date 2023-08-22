<template>
  <form action="">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" id="floatingInput" placeholder="Ingredient name...">
      <label for="floatingInput">Ingredient name</label>
    </div>
    <div class="form-floating mb-3">
      <input type="text" class="form-control" id="floatingInput" placeholder="ingredient Quantity">
      <label for="floatingInput">Ingredient Quantity</label>
    </div>
  </form>
</template>


<script>
import { ref } from "vue";

export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      async createIngredient() {

      }
    }
  }
}
</script>


<style lang="scss" scoped></style>