(ns pangram
  (:require [clojure.string :as str]))

(defn all-letters-in [sentence]
  (set (re-seq #"[a-z]" (str/lower-case sentence))))

(defn pangram? [sentence]
  (= (count (all-letters-in sentence)) 26))
