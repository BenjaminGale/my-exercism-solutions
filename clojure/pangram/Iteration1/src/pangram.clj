(ns pangram
  (:require [clojure.string :as str]))

(defn pangram? [sentence]
  (= (set (str/lower-case (str/replace sentence #"\s|_|\"|[1-9]|\." ""))) (set "abcdefghijklmnopqrstuvwxyz"))
)
