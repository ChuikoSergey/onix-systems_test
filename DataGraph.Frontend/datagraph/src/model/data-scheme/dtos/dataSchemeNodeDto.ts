export class DataSchemeNodeDto {
    public name! : string;
    public primaryKeyFields? : string[] | undefined;
    public foreignKeyFields? : string[] | undefined;

    constructor(init?:Partial<DataSchemeNodeDto>) {
        Object.assign(this, init);
    }
}