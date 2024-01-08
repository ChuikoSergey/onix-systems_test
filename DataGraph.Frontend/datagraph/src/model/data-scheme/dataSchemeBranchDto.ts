export class DataSchemeBranchDto {
    public fromNode! : string;
    public toNode! : string;

    constructor(init?:Partial<DataSchemeBranchDto>) {
        Object.assign(this, init);
    }
}