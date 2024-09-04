<template>
    <LayoutEscola>
        <v-container>
            <h4 class="text-h4">Nova sala</h4>
            <form class="mt-3" @submit.prevent="novaSala">
                <v-row>
                    <v-col cols="12" md="6">
                        <v-text-field
                            label="Sala de aula *"
                            required
                            v-model="nome"
                            :rules="[v => !!v || 'Este campo é obrigatório']"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="6">
                        <v-text-field
                            v-model="descricao"
                            label="Descriçäo (Opcional)"
                        ></v-text-field>
                    </v-col>
                </v-row>
                <v-btn class="me-4" color="light-blue-darken-3" type="submit">
                    Salvar
                </v-btn>
                <v-btn :to="{ name: 'SalasEscola' }">
                    Voltar
                </v-btn>
            </form>
        </v-container>            
    </LayoutEscola>    
</template>

<script>
    import LayoutEscola from '@/layouts/layoutEscola.vue';
    import axios from 'axios';
    import jwt_decode from 'jwt-decode';
    import Cookies from 'js-cookie';

    export default{
        components: {
            LayoutEscola
        },
        data(){
            return {
                nome: '',
                descricao: '',
                escola_id: null,
                token: '',
                decodedToken: ''
            }
        },
        methods: {
            novaSala(){
                this.token = Cookies.get('escola_token');
                this.decodedToken = jwt_decode(this.token);
                const novaSalas = {
                    nome : this.nome,
                    descricao : this.descricao,
                    escola_id : parseInt(this.decodedToken.sub, 10)
                };
                
                axios.post('clases', novaSalas, {
                    headers: {
                    'Content-Type': 'application/json'
                    }
                })
                .then(response => {
                    console.log('Sala salva com sucesso:', response.data);
                    this.$router.push('/escola/salas');
                })
                .catch(error => {
                    console.error('Erro ao salvar a sala:', error.message);
                    this.$router.push('/escola/NovaSala');
                });
            }
        }
    }
</script>      