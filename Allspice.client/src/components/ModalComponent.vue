<template>
  <div class="modal fade" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-body">

          <slot name="body"></slot>

        </div>

      </div>
    </div>
  </div>
</template>


<script>
export default {
  setup() {


    return {}
  }
}
</script>


<style lang="scss" scoped></style>