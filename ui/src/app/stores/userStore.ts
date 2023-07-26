//create a store for the user including an isLoggedIn property and a way to set it 

import { makeAutoObservable } from "mobx";
import { store } from "./store";


export default class UserStore {
    constructor() { 
        makeAutoObservable(this);
    }

    isLoggedIn = false;
    logInButtonText = 'Login';
    setIsLoggedIn = (state: boolean) => {   
        if (state === true) {
            store.drawerStore.setDrawerIsVisible(true);
            store.drawerStore.setDrawerWidth(240);
            this.logInButtonText = 'Log Out';
        }
        if (state === false) {
            store.drawerStore.setDrawerIsVisible(false);
            store.drawerStore.setDrawerWidth(0);
            this.logInButtonText = 'Log In';
        }
        this.isLoggedIn = state;
    }
}