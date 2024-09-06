<template>
    <LayoutEscola>
        <v-container>
            <h4 class="text-h4">Novo professor</h4>
            <form class="mt-3" @submit.prevent="novoProfessor">
                <v-row>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="Nome *"
                            v-model="nome"
                            required
                            :rules="[v => !!v || 'Este campo é obrigatório']"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field
                            v-model="cpf"
                            label="CPF"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="E-mail *"
                            v-model="email"
                            type="email"
                            required
                            :rules="[v => !!v || 'Este campo é obrigatório']"
                        ></v-text-field>
                    </v-col>    
                </v-row>
                <v-row>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="Telefone *"
                            v-model="telefone"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="Senha* (Senha para o painel do professor)"
                            v-model="senha"
                            type="password"
                            required
                            :rules="[v => !!v || 'Este campo é obrigatório']"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field disabled
                            label="Numero de inscricao (Gerado altomatico)"
                            v-model="inscricao"
                        ></v-text-field>
                    </v-col>
                </v-row>
                <v-btn class="me-4" color="light-blue-darken-3" type="submit">
                    Salvar
                </v-btn>
                <v-btn :to="{ name: 'ProfessorEscola' }">
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
        data: () => ({
            items: '',
            nome: '',
            cpf: '',
            email: '',
            telefone: '',
            inscricao: '',
            senha: '',
            escola_id: null,
            token: '',
            decodedToken: ''
        }),
        methods: {
            novoProfessor(){
                this.token = Cookies.get('escola_token');
                this.decodedToken = jwt_decode(this.token);
                const inscricaofor = new Date().toISOString().replace(/[-:T.]/g, '').slice(0, 14) + Math.floor(Math.random() * 100).toString().padStart(2, '0');
                const novoProfessors = {
                    nome: this.nome,
                    cpf: this.cpf,
                    email: this.email,
                    telefone: this.telefone,
                    inscricao: inscricaofor,
                    senha: this.senha,
                    escola_id: parseInt(this.decodedToken.sub, 10),
                };
                console.log(novoProfessors)
                axios.post('professor', novoProfessors, {
                    headers: {
                    'Content-Type': 'application/json'
                    }
                })
                .then(response => {
                    console.log('Professor salva com sucesso:', response.data);
                    this.$router.push('/escola/professores');
                })
                .catch(error => {
                    console.error('Erro ao salvar a aluno:', error.message);
                    this.$router.push('/escola/novoProfessor');
                });
            },
        }
    }
</script>      