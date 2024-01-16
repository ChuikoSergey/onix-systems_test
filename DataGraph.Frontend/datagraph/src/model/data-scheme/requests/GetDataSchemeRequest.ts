export class GetDataSchemeRequest {
    public connectionString! : string;

    constructor(init?:Partial<GetDataSchemeRequest>) {
        Object.assign(this, init);
    }
}