<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12">
        <form @submit.prevent="createRecipe()">
          <div class="form-floating mb-3">
            <input v-model="editable.title" required type="text" class="form-control" id="title"
              placeholder="Title goes Here">
            <label for="title">Title</label>
          </div>
          <div class="form-floating mb-3">
            <input v-model="editable.img" required type="url" class="form-control" id="img"
              placeholder="image link goes here">
            <label for="img">Img</label>
          </div>
          <div class="form-floating mb-3">
            <select v-model="editable.category" required class="form-select" name="category" id="category">
              <option value="Cheese">Cheese</option>
              <option value="Italian">Italian</option>
              <option value="Soup">Soup</option>
              <option value="Mexican">Mexican</option>
              <option value="Specialty Coffee">Specialty Coffee</option>
            </select>
          </div>
          <div class="form-floating mb-3">
            <textarea v-model="editable.instructions" required class="form-control" name="instructions" id="instructions"
              style="height:200px"></textarea>
            <label for="instructions">Instructions</label>
          </div>
          <input class="btn btn-primary" type="submit">
        </form>
      </div>
    </div>
  </div>
</template>


<script>
import { ref } from "vue";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { recipesService } from "../services/RecipesService.js";

export default {
  setup() {
    const editable = ref({})

    return {
      editable,
      async createRecipe() {
        try {
          const formData = editable.value
          await recipesService.createRecipe(formData)
        } catch (error) {
          Pop.error(error.message)
          logger.log(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>