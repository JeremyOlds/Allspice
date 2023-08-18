<template>
  <div class="container-fluid">
    <div class="row banner">
      <!-- SECTION Banner -->
      <div class="text-white col-12 d-flex flex-column align-items-center justify-content-center m-auto mt-5 elevation-5">
        <div>
          <h2>All-Spice</h2>
          <h3>Cherish Your Family</h3>
          <h3>And Their Cooking</h3>
        </div>
      </div>
      <!-- SECTION search bar -->
      <div class="col-12 d-flex justify-content-center">
        <form class="text-white" @submit.prevent="filterRecipes()">
          <label for="Recipes">Search: </label>
          <input v-model="filterBy" type="search" id="Recipes" class="rounded">
          <button type="submit" class="btn btn-primary"><i class="mdi mdi-magnify"></i></button>
        </form>
      </div>
      <!-- SECTION categories -->
      <div class="col-md-6 col-12 d-flex justify-content-around">
        <button @click="setCategory('')" class="btn btn-primary my-2">All</button>
        <button @click="setCategory('cheese')" class="btn btn-primary my-2">Cheese</button>
        <button @click="setCategory('italian')" class="btn btn-primary my-2">Italian</button>
      </div>
      <div class="col-md-6 col-12 d-flex justify-content-around">
        <button @click="setCategory('soup')" class="btn btn-primary my-2">Soup</button>
        <button @click="setCategory('mexican')" class="btn btn-primary my-2">Mexican</button>
        <button @click="setCategory('specialty coffee')" class="btn btn-primary my-2">Specialty Coffee</button>
      </div>
    </div>
    <!-- SECTION recipes listed -->
    <div class="row">
      <div v-for="r in recipes" :key="r.id" class="col-md-3 col-12">
        <RecipeComponent :recipeProp="r" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, ref } from "vue";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { recipesService } from "../services/RecipesService.js"
import { AppState } from "../AppState.js";
import RecipeComponent from "../components/RecipeComponent.vue";

export default {
  setup() {
    const filterBy = ref('');
    const category = ref('')
    async function getRecipes() {
      try {
        await recipesService.getRecipes();
      }
      catch (error) {
        Pop.error(error.message);
        logger.log(error);
      }
    }
    onMounted(() => {
      getRecipes();
    });

    return {
      filterBy,
      category,
      recipes: computed(() => {

        let filtered = AppState.recipes.filter(r => (filterBy.value ? r.title.toLowerCase().includes(filterBy.value.toLowerCase()) : true))
        if (category.value != '') {
          filtered = filtered.filter(r => (category.value ? r.category.toLowerCase().includes(category.value.toLowerCase()) : true))
        }
        return filtered

      }),
      setCategory(selectedcategory) {
        category.value = selectedcategory;
      }

    };
  },
  components: { RecipeComponent }
}
</script>

<style scoped lang="scss">
.banner {
  background-image: url("https://media.istockphoto.com/id/477756915/photo/seamless-texture-with-spices-and-herbs.jpg?s=612x612&w=0&k=20&c=t9fckmk-oIJvwLgg-wA-DW6830JpAFtUmmVrr-JjmRc=");
}

.selected-category {
  box-shadow: 0px 0px 5px 5px red;
}
</style>
