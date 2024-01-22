import React, { useState } from "react";
import { Formik, Field, Form, ErrorMessage } from "formik";
import apiService from "../services/apiService";

interface AuctionCreationType {
  endsAt: string;
  startingPrice: string;
  minimumPrice: string;
  estimatedMinimum: string;
  estimatedMaximum: string;
  product: {
    height: string;
    width: string;
    depth: string;
    weight: string;
    year: string;
    title: string;
    description: string;
    artist: string;
  };
}

interface BuyNowCreationType {
  price: string;
  product: {
    height: string;
    width: string;
    depth: string;
    weight: string;
    year: string;
    title: string;
    description: string;
    artist: string;
  };
}

const LotForm = () => {
  const [saleType, setSaleType] = useState("buyNow");

  type FormValues = AuctionCreationType | BuyNowCreationType;

  const initialValues: FormValues = {
    endsAt: "",
    startingPrice: "",
    minimumPrice: "",
    estimatedMinimum: "",
    estimatedMaximum: "",
    price: "",
    product: {
      height: "",
      width: "",
      depth: "",
      weight: "",
      year: "",
      title: "",
      description: "",
      artist: "",
    },
  };

  const onSubmit = (values: FormValues) => {
    if (saleType === "auction") {
      const { price, ...auctionDto } = values as any;
      apiService.post("/auctions", auctionDto);
    } else {
      const {
        endsAt,
        startingPrice,
        minimumPrice,
        estimatedMaximum,
        estimatedMinimum,
        ...buyNowDto
      } = values as any;
      apiService.post("/fixedPriceListings", buyNowDto);
    }
  };

  return (
    <Formik initialValues={initialValues} onSubmit={onSubmit}>
      <Form className="flex flex-col gap-2 w-1/3">
        <label htmlFor="saleType">Sale Type</label>
        <Field
          as="select"
          id="saleType"
          name="saleType"
          onChange={(e: any) => setSaleType(e.target.value)}
          className="border border-light-gray rounded px-2"
        >
          <option value="buyNow">Buy Now</option>
          <option value="auction">Auction</option>
        </Field>
        <ErrorMessage name="saleType" component="div" />

        {saleType === "auction" && ( // display auction related inputs
          <>
            <label htmlFor="endsAt">Ends At</label>
            <Field
              type="datetime-local"
              id="endsAt"
              name="endsAt"
              className="border border-light-gray rounded px-2"
            />
            <ErrorMessage name="endsAt" component="div" />

            <label htmlFor="startingPrice">Starting Price</label>
            <Field
              type="number"
              id="startingPrice"
              name="startingPrice"
              className="border border-light-gray rounded px-2"
            />
            <ErrorMessage name="startingPrice" component="div" />

            <label htmlFor="minimumPrice">Minimum Price</label>
            <Field
              type="number"
              id="minimumPrice"
              name="minimumPrice"
              className="border border-light-gray rounded px-2"
            />
            <ErrorMessage name="minimumPrice" component="div" />

            <label htmlFor="estimatedMinimum">Estimated Minimum</label>
            <Field
              type="number"
              id="estimatedMinimum"
              name="estimatedMinimum"
              className="border border-light-gray rounded px-2"
            />
            <ErrorMessage name="estimatedMinimum" component="div" />

            <label htmlFor="estimatedMaximum">Estimated Maximum</label>
            <Field
              type="number"
              id="estimatedMaximum"
              name="estimatedMaximum"
              className="border border-light-gray rounded px-2"
            />
            <ErrorMessage name="estimatedMaximum" component="div" />
          </>
        )}

        {saleType === "buyNow" && (
          <>
            <label htmlFor="price">Price</label>
            <Field
              type="price"
              id="price"
              name="price"
              className="border border-light-gray rounded px-2"
            />
            <ErrorMessage name="price" component="div" />
          </>
        )}

        <label htmlFor="product.height">Height</label>
        <Field
          type="number"
          id="product.height"
          name="product.height"
          className="border border-light-gray rounded px-2"
        />
        <ErrorMessage name="product.height" component="div" />

        <label htmlFor="product.width">Width</label>
        <Field
          type="number"
          id="product.width"
          name="product.width"
          className="border border-light-gray rounded px-2"
        />
        <ErrorMessage name="product.width" component="div" />

        <label htmlFor="product.depth">Depth</label>
        <Field
          type="number"
          id="product.depth"
          name="product.depth"
          className="border border-light-gray rounded px-2"
        />
        <ErrorMessage name="product.depth" component="div" />

        <label htmlFor="product.weight">Weight</label>
        <Field
          type="number"
          id="product.weight"
          name="product.weight"
          className="border border-light-gray rounded px-2"
        />
        <ErrorMessage name="product.weight" component="div" />

        <label htmlFor="product.year">Year</label>
        <Field
          type="number"
          id="product.year"
          name="product.year"
          className="border border-light-gray rounded px-2"
        />
        <ErrorMessage name="product.year" component="div" />

        <label htmlFor="product.title">Title</label>
        <Field
          type="text"
          id="product.title"
          name="product.title"
          className="border border-light-gray rounded px-2"
        />
        <ErrorMessage name="product.title" component="div" />

        <label htmlFor="product.description">Description</label>
        <Field
          type="text"
          id="product.description"
          name="product.description"
          className="border border-light-gray rounded px-2"
        />
        <ErrorMessage name="product.description" component="div" />

        <label htmlFor="product.artist">Artist</label>
        <Field
          type="text"
          id="product.artist"
          name="product.artist"
          className="border border-light-gray rounded px-2"
        />
        <ErrorMessage name="product.artist" component="div" />

        <button type="submit" className="bg-main-green p-2 text-xl mt-2">
          Submit
        </button>
      </Form>
    </Formik>
  );
};

export default LotForm;
