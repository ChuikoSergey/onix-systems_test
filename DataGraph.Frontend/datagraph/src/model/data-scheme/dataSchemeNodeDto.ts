export class DataSchemeNodeDto {
    public name! : string;
    public primaryKeyName! : string;
    public foreignKeyFields? : string[] | undefined;

    constructor(init?:Partial<DataSchemeNodeDto>) {
        Object.assign(this, init);
    }
}