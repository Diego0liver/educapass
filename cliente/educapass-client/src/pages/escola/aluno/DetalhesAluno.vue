<template>
    <LayoutEscola>
        <v-card
            class="mx-auto"
            :subtitle="nome"
            prepend-icon="mdi-account-school"
            width="1000">
            <template v-slot:append>
                <v-btn
                class="text-none"
                color="primary"
                text="Create goal"
                variant="Voltar"
                prepend-icon="mdi-keyboard-backspace"
                :to="{ name: 'AlunosEscola' }">
                Voltar
                </v-btn>
            </template>
            <template v-slot:title>
                <span class="font-weight-black"></span>
            </template>
            <v-card-text class="bg-surface-light pt-4">
                <v-list lines="two" class="rounded">
                    <v-list-item
                        :subtitle="inscricao">
                        <template v-slot:title>
                            Inscricao<span class="font-weight-black"></span>
                        </template>
                    </v-list-item>
                    <v-divider></v-divider>
                    <v-list-item
                        :subtitle="clase">
                        <template v-slot:title>
                            Sala de aula<span class="font-weight-black"></span>
                        </template>
                    </v-list-item>
                    <v-divider></v-divider>
                    <v-list-item
                        :subtitle="email">
                        <template v-slot:title>
                            E-mail<span class="font-weight-black"></span>
                        </template>
                    </v-list-item>
                    <v-divider></v-divider>
                    <v-list-item
                        :subtitle="telefone">
                        <template v-slot:title>
                            Telefone<span class="font-weight-black"></span>
                        </template>
                    </v-list-item>
                    <v-divider></v-divider>
                    <v-list-item
                        :subtitle="cpf">
                        <template v-slot:title>
                            CPF<span class="font-weight-black"></span>
                        </template>
                    </v-list-item>
                    <v-divider></v-divider>
                    <v-list-item
                        :subtitle="dataNascimento">
                        <template v-slot:title>
                            Data nascimento<span class="font-weight-black"></span>
                        </template>
                    </v-list-item>
                    <v-divider></v-divider>
                    <v-list-item
                        :subtitle="responsavel">
                        <template v-slot:title>
                            Responsavel<span class="font-weight-black"></span>
                        </template>
                    </v-list-item>
                    <v-divider></v-divider>
                    <v-list-item
                        :subtitle="contatoResponsavel">
                        <template v-slot:title>
                            Contato do responsavel<span class="font-weight-black"></span>
                        </template>
                    </v-list-item>
                    <v-divider></v-divider>
                    <v-list-item
                        :subtitle="numeroChamada">
                        <template v-slot:title>
                            Numero da chamada<span class="font-weight-black"></span>
                        </template>
                    </v-list-item>
                    <v-divider></v-divider>
                    <v-list-item
                        :subtitle="totalFalta">
                        <template v-slot:title>
                            Total de faltas<span class="font-weight-black"></span>
                        </template>
                    </v-list-item>
                </v-list>
            </v-card-text>
        </v-card>
        <v-card
            class="mx-auto mt-4"
            subtitle="Notas"
            prepend-icon="mdi-notebook-edit"
            width="1000">
            <v-card-text class="bg-surface-light pt-4">
                <v-list lines="two" class="rounded">
                    <v-list-item
                        :subtitle="inscricao">
                        <template v-slot:title>
                            Inscricao<span class="font-weight-black"></span>
                        </template>
                    </v-list-item>
                </v-list>
            </v-card-text>
        </v-card>
    </LayoutEscola>
</template>

<script>
import LayoutEscola from '@/layouts/layoutEscola.vue';
import { useRoute } from 'vue-router';
import axios from 'axios';

export default {
    components: {
        LayoutEscola
    },
    data() {
        return {
            id: null,
            nome: '',
            email: '',
            inscricao: '',
            telefone: '',
            cpf: '',
            dataNascimento: '',
            responsavel: '',
            contatoResponsavel: '',
            numeroChamada: 0,
            totalFalta: 0,
            clase: ''
        };
    },
    mounted() {
        const route = useRoute();
        this.id = route.params.id;
        
        axios.get(`alunos/${this.id}`).then((res)=>{
            this.nome = res.data.res.nome
            this.email = res.data.res.email
            this.inscricao = res.data.res.inscricao
            this.telefone = res.data.res.telefone
            this.cpf = res.data.res.cpf
            this.dataNascimento = 
            new Date(res.data.res.dataNascimento).toLocaleDateString('pt-BR', {
                day: '2-digit',
                month: '2-digit',
                year: 'numeric'
            });
            this.responsavel = res.data.res.responsavel
            this.contatoResponsavel = res.data.res.contatoResponsavel
            this.numeroChamada = res.data.res.numeroChamada
            this.totalFalta = res.data.res.totalFalta
            this.clase = res.data.res.clase.nome + ' | ' + res.data.res.clase.descricao
            console.log(this.nome);
        })
    }
}
</script>