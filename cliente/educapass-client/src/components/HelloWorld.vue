<template>
  <v-container class="fill-height">
    <v-responsive
      class="align-centerfill-height mx-auto"
      max-width="900"
    >
      <v-img
        class="mb-4"
        height="48"
        src="@/assets/logoEducapass.png"
      />

      <div class="text-center">
        <div class="text-body-2 font-weight-light mb-n1"></div>

        <h1 class="text-h2 font-weight-bold font-new">{{ escolaID }}</h1>
      </div>

      <div class="py-4" />

    </v-responsive>
  </v-container>
</template>

<script setup>
import axios from 'axios';
import { ref } from 'vue';

const escolaID = ref()
axios.get('escola/1').then((res)=>{
  escolaID.value = res.data.res.nome
  console.log(res.data.res);
})
</script>

<style scoped>
  .font-new {
  font-family: "Quicksand", sans-serif;
  font-optical-sizing: auto;
  font-weight: 552;
  font-style: normal;
  }
</style>