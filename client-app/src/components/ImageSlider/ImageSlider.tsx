import React from "react";
import "react-responsive-carousel/lib/styles/carousel.min.css";
import { Carousel } from "react-responsive-carousel";

import "./ImageSlider.scss";

type imagesType = {
  path: string;
  text: string;
};

type ImageSliderProps = {
  images: Array<imagesType>;
  sliderClassName: any;
  containerClassName: any;
  imageClassName: any;
  textClassName: any;
};

const ImageSlider: React.FC<ImageSliderProps> = (props) => {
  const {
    images,
    sliderClassName,
    containerClassName,
    imageClassName,
    textClassName,
  } = props;

  return (
    <Carousel
      className={sliderClassName}
      axis="horizontal"
      interval={3000}
      autoPlay
      dynamicHeight
      infiniteLoop
      showThumbs={false}
      showArrows={false}
      showStatus={false}
    >
      {images.map((i: imagesType) => (
        <div className={containerClassName}>
          <img className={imageClassName} src={i.path} />
          <p className={textClassName}>{i.text}</p>
        </div>
      ))}
    </Carousel>
  );
};

export default ImageSlider;
