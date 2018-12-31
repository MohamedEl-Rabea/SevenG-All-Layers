<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="business-cards-category.aspx.cs" Inherits="sevenG.Products.business_cards_category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="card">
                    <div class="card-header card-header-info">
                        <h4 class="card-title"><strong>Business Cards</strong></h4>
                        <p class="card-category">Design your card</p>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Product name</label>
                                    <input type="text" name="cardType" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Material</label>
                                    <input type="text" name="material" class="form-control">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Size</label>
                                    <input type="email" name="size" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Special Effect</label>
                                    <input type="text" name="specialEffect" class="form-control">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Lamination</label>
                                    <input type="text" name="lamination" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Round Corner</label>
                                    <input type="text" name="roundCorner" class="form-control">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Sides</label>
                                    <input type="text" name="sides" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Print Type</label>
                                    <input type="text" name="printType" value="Printer name would be here" class="form-control">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="row">
                        <img src="../assets/img/smaple.jpg" style="margin: 5px auto" width="400" height="250" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="card">
                    <div class="card-header card-header-info">
                        <h4 class="card-title "><strong>Amounts & Prices</strong></h4>
                        <p class="card-category">Choose your offer from list below</p>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table class="table">
                                <th>Amount</th>
                                <th>Price</th>
                                <th></th>
                                <tbody>
                                    <tr>
                                        <td>
                                            <input type="text" placeholder="Enter custom amount" class="form-control">
                                        </td>
                                        <td class="text-primary">
                                            <input type="text" placeholder="Enter custom price" class="form-control">
                                        </td>
                                        <td>
                                            <input type="button" class="btn btn-sm btn-success" value="Add To Cart" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>1000</td>
                                        <td class="text-primary">$36,738</td>
                                        <td>
                                            <input type="button" class="btn btn-sm btn-success" value="Add To Cart" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>1000</td>
                                        <td class="text-primary">$36,738</td>
                                        <td>
                                            <input type="button" class="btn btn-sm btn-success" value="Add To Cart" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>1000</td>
                                        <td class="text-primary">$36,738</td>
                                        <td>
                                            <input type="button" class="btn btn-sm btn-success" value="Add To Cart" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>1000</td>
                                        <td class="text-primary">$36,738</td>
                                        <td>
                                            <input type="button" class="btn btn-sm btn-success" value="Add To Cart" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>1000</td>
                                        <td class="text-primary">$36,738</td>
                                        <td>
                                            <input type="button" class="btn btn-sm btn-success" value="Add To Cart" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="card">
                <div class="card-header card-header-info">
                    <h4 class="card-title "><strong>Design You Card</strong></h4>
                    <p class="card-category">Select from images below</p>
                </div>
                <div class="card-body">
                    <div class="accordion" id="accordionExample">
                        <div class="card" style="margin: 5px 0 0 0; position: relative">
                            <div class="card-header" style="background-color: #f0f0f0" id="headingOne">
                                <h5 class="mb-0">
                                    <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                        <strong style="color: #000000">Card type</strong>
                                    </button>
                                </h5>
                            </div>
                            <div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="card card2" data-field="cardType" data-value="Metalic" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/Metallic-Business-card.png" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">Metalic</strong>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="card card2" data-field="cardType" data-value="Textural" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/textured_Card.jpg" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">Textural</strong>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="card card2" data-field="cardType" data-value="Digital print" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/digital_printing_Card.jpg" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">Digital print</strong>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="card card2" data-field="cardType" data-value="Colored paper" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/colord_paper_card.jpg" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">Colored paper</strong>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="card card2" data-field="cardType" data-value="Synthetic" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/synthetic.jpg" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">Synthetic</strong>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="card card2" data-field="cardType" data-value="Special effect" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/special effectjpg.jpg" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">Special effect</strong>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card" style="margin: 5px 0 0 0; position: relative">
                            <div class="card-header" style="background-color: #f0f0f0" id="headingTwo">
                                <h5 class="mb-0">
                                    <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                        <strong style="color: #000000">Material type</strong>
                                    </button>
                                </h5>
                            </div>
                            <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="card card2" data-field="material" data-value="300 Coated Gloss" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/coated-glossy-paper-500x500.jpg" alt="Card image cap">
                                                <div class="card-body">
                                                    <small class="card-title">300 Coated Gloss</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="card card2" data-field="material" data-value="200 Coated Gloss" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/coated-glossy-paper-500x500.jpg" alt="Card image cap">
                                                <div class="card-body">
                                                    <small class="card-title">200 Coated Gloss</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="card card2" data-field="material" data-value="150 Coated Gloss" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/coated-glossy-paper-500x500.jpg" alt="Card image cap">
                                                <div class="card-body">
                                                    <small class="card-title">150 Coated Gloss</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="card card2" data-field="material" data-value="135 Coated Gloss" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/coated-glossy-paper-500x500.jpg" alt="Card image cap">
                                                <div class="card-body">
                                                    <small class="card-title">135 Coated Gloss</small>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card" style="margin: 5px 0 0 0; position: relative">
                            <div class="card-header" style="background-color: #f0f0f0" id="headingThree">
                                <h5 class="mb-0">
                                    <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                        <strong style="color: #000000">Size</strong>
                                    </button>
                                </h5>
                            </div>
                            <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="card card2" data-field="size" data-value="3.5 * 2" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/spec_blank_l.png" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">3.5 * 2</strong>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="card card2" data-field="size" data-value="3.5 * 2.5" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/spec_blank_l.png" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">3.5 * 2.5</strong>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="card card2" data-field="size" data-value="3.5 * 3.5" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/spec_blank_l.png" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">3.5 * 3.5</strong>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card" style="margin: 5px 0 0 0; position: relative">
                            <div class="card-header" style="background-color: #f0f0f0" id="headingFour">
                                <h5 class="mb-0">
                                    <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseFour" aria-expanded="false" aria-controls="collapseThree">
                                        <strong style="color: #000000">Special effect</strong>
                                    </button>
                                </h5>
                            </div>
                            <div id="collapseFour" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="card card2" data-field="specialEffect" data-value="None" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/spec_blank_l.png" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">None</strong>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="card card2" data-field="specialEffect" data-value="Spot UV1" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/spot_uv.jpg" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">Spot UV1</strong>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="card card2" data-field="specialEffect" data-value="Spot UV2" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/soptuvraised-cards-2.jpg" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">Spot UV2</strong>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card" style="margin: 5px 0 0 0; position: relative">
                            <div class="card-header" style="background-color: #f0f0f0" id="headingFive">
                                <h5 class="mb-0">
                                    <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseFive" aria-expanded="false" aria-controls="collapseThree">
                                        <strong style="color: #000000">Lamination</strong>
                                    </button>
                                </h5>
                            </div>
                            <div id="collapseFive" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="card card2" data-field="lamination" data-value="1 side matt lamination" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/lamination.jpg" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">1 side matt lamination</strong>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="card card2" data-field="lamination" data-value="2 side matt lamination" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/lamination2.jpg" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">2 side matt lamination</strong>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="card card2" data-field="lamination" data-value="1 side gloss lamination" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/lamination3.jpg" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">1 side gloss lamination</strong>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="card card2" data-field="lamination" data-value="2 side gloss lamination" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/lamination4.jpg" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">2 side gloss lamination</strong>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card" style="margin: 5px 0 0 0; position: relative">
                            <div class="card-header" style="background-color: #f0f0f0" id="headingSix">
                                <h5 class="mb-0">
                                    <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseSix" aria-expanded="false" aria-controls="collapseThree">
                                        <strong style="color: #000000">Round corner</strong>
                                    </button>
                                </h5>
                            </div>
                            <div id="collapseSix" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="card card2" data-field="roundCorner" data-value="Top left" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/rounded_corners.png" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">Top left</strong>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="card card2" data-field="roundCorner" data-value="Top right" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/rounded_corners.png" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">Top right</strong>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="card card2" data-field="roundCorner" data-value="Bottom left" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/rounded_corners.png" alt="Card image cap">
                                                <div class="card-body">
                                                    <small style="padding: 0; margin: 0" class="card-title">Bottom left</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="card card2" data-field="roundCorner" data-value="Bottom right" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/rounded_corners.png" alt="Card image cap">
                                                <div class="card-body">
                                                    <small style="padding: 0; margin: 0" class="card-title">Bottom righ</small>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card" style="margin: 5px 0 0 0; position: relative">
                            <div class="card-header" style="background-color: #f0f0f0" id="headingSeven">
                                <h5 class="mb-0">
                                    <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseSeven" aria-expanded="false" aria-controls="collapseThree">
                                        <strong style="color: #000000">Print Sides</strong>
                                    </button>
                                </h5>
                            </div>
                            <div id="collapseSeven" class="collapse" aria-labelledby="headingSeven" data-parent="#accordionExample">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="card card2" data-field="sides" data-value="1 side" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/spec_oneside.png" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">1 side</strong>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="card card2" data-field="sides" data-value="2 sides" style="margin: 0">
                                                <img class="card-img-top" src="../assets/img/spec_twoside.png" alt="Card image cap">
                                                <div class="card-body">
                                                    <strong class="card-title">2 sides</strong>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
