<template>
  <div class="body">

    <v-container class="fill-height">
      <v-card
          class="mx-auto"
        >
          <v-card-item>
      <v-responsive
        class="align-centerfill-height mx-auto"
        max-width="900">
        <v-img
          class="mb-4"
          height="48"
          src="@/assets/logoEducapass.png"/>
        <div class="text-center">
          <h3 class="text-h3 font-weight-bold font-new">Educapass</h3>
          <v-alert v-if="error"
            :text='error'
            type="error"
            class="mt-2"
            variant="tonal"
          ></v-alert>
          
        </div>
        <v-sheet class="mx-auto mt-5" width="400">
          <v-form fast-fail @submit.prevent="loginEscola">
            <v-text-field
              label="E-mail"
              type="email"
              v-model="email"
            ></v-text-field>
            <v-text-field
              label="Senha"
              v-model="senha"
              type="password"
            ></v-text-field>
            <v-btn class="mt-2 mb-5" color="indigo" type="submit" block>Logar</v-btn>
          </v-form>
        </v-sheet>
      </v-responsive>
    </v-card-item>
      </v-card>
    </v-container>
  </div>
</template>

<script>
import axios from 'axios';
import Cookies from 'js-cookie';

export default{
  data(){
    return {
      email: '',
      senha: '',
      error: ''
    }
  },
  methods:{
    loginEscola(){
      const loginDados = {
        email: this.email,
        senha: this.senha
      }
      axios.post('escola', loginDados, {
            headers: {
            'Content-Type': 'application/json'
            }
        })
        .then(response => {
          console.log(response.data.token);
          Cookies.set('escola_token', response.data.token)
          this.$router.push('/escola');
        })
        .catch(error => {
          if(error.response){
            console.error('erro', error.response.data.mensagem);
            this.error = error.response.data.mensagem
          }else{
            console.error('erro', error.message);
            this.error = 'Error, tente novamente mais tarde: ' + error.message
          }
        });
    }
  }
}
</script>

<style scoped>
  .font-new {
  font-family: "Quicksand", sans-serif;
  font-optical-sizing: auto;
  font-weight: 552;
  font-style: normal;
  }
  .body{
    font-family: "Quicksand", sans-serif;
    font-optical-sizing: auto;
    background: linear-gradient(302deg, rgba(197,202,233,1) 0%, rgba(63,81,181,1) 100%);
    width: 100%;
    height: 100%;
  }
</style>