import { DataSchemeBranchDto } from "./dataSchemeBranchDto";
import { DataSchemeNodeDto } from "./dataSchemeNodeDto";

export class DataSchemeDto {
    public nodes : DataSchemeNodeDto[] = [];
    public branches : DataSchemeBranchDto[] = [];

    constructor(init?:Partial<DataSchemeDto>) {
        Object.assign(this, init);
    }
}