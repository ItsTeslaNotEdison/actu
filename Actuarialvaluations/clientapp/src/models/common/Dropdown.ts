/**
 * The Dropdown model class
 */
export class Dropdown {
    /**
     * The Value for dropdown
     */
    public value: number | null = null;

    /**
     * The Text Dropdown
     */
    public text: string | null = null;


    constructor(value: number, text: string) {
        if (text) {
            this.value = value;
            this.text = text;
        }
    }
}