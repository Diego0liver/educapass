<template>
    <LayoutEscola>
        <v-container>
            <h4 class="text-h4">Novo aluno</h4>
            <form class="mt-3">
                <v-row>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="Nome"
                            required
                            :rules="[v => !!v || 'Este campo é obrigatório']"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="CPF"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="E-mail"
                            type="E-mail"
                            required
                            :rules="[v => !!v || 'Este campo é obrigatório']"
                        ></v-text-field>
                    </v-col>    
                </v-row>

                <v-row>
                    <v-col cols="12" md="4">
                        <v-text-field 
                            label="Data nascimento"
                            type="date"
                            required
                            :rules="[v => !!v || 'Este campo é obrigatório']"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="Numero chamada"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field disabled
                            label="Numero de inscricao (Gerado altomatico)"
                        ></v-text-field>
                    </v-col>    
                </v-row>

                <v-row>
                    <v-col cols="12" md="3">
                        <v-text-field
                            label="Nome do pai"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="3">
                        <v-text-field
                            label="Contato do pai"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="3">
                        <v-text-field
                            label="Nome da mae"
                             type="E-mail"
                        ></v-text-field>
                    </v-col>  
                    <v-col cols="12" md="3">
                        <v-text-field
                            label="Contato mae"
                             type="E-mail"
                        ></v-text-field>
                    </v-col>    
                </v-row>

                <v-row>
                    <v-col cols="12" md="3">
                        <v-text-field
                            label="Faltas"
                            type="number"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="9">
                        <v-text-field
                            label="Senha"
                            type="password"
                            required
                            :rules="[v => !!v || 'Este campo é obrigatório']"
                        ></v-text-field>
                    </v-col>
                </v-row>
                <v-btn class="me-4" color="light-blue-darken-3" type="submit">
                    Salvar
                </v-btn>
                <v-btn :to="{ path: '/escola/AlunosEscola' }">
                    Voltar
                </v-btn>
            </form>
        </v-container>            
    </LayoutEscola>    
</template>
  

<script>
    import LayoutEscola from '@/layouts/layoutEscola.vue';
        export default{
            components: {
                LayoutEscola
            }
        }     
</script>      