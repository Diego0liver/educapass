import Cookies from 'js-cookie';

export default {
    authEscola(to, from, next){
        const getToken = Cookies.get('escola_token')
    
        if(!getToken){
            next('/');
        }
        next();
    },

    authEscolaViewLogin(to, from, next){
        const getToken = Cookies.get('escola_token')
    
        if(getToken){
            next('/escola');
        }
        next();
    }
}