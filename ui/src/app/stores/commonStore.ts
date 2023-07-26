import { makeAutoObservable } from "mobx";

export default class CommonStore {
    mobileOpen: boolean = false;

    constructor() {
        makeAutoObservable (this);
    }
    setMobileOpen = (state: boolean) => {
        this.mobileOpen = state;
    }
    
}